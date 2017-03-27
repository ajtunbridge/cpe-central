#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using NcCommunicator.Data.Model;

#endregion

namespace NcCommunicator.Data.Repositories
{
    public class MachineRepository : RepositoryBase
    {
        public MachineRepository(MachinesDataSet dataSet) : base(dataSet)
        {
        }

        public Machine GetById(int id)
        {
            Machine match = null;

            foreach (MachinesDataSet.MachinesRow row in DataSet.Machines.Rows) {
                if (row.Id != id) {
                    continue;
                }

                match = new Machine {
                    Id = row.Id,
                    Name = row.Name,
                    ComPort = row.ComPort,
                    MachineControlId = row.MachineControlId
                };

                if (!string.IsNullOrWhiteSpace(row.Base64Photo)) {
                    var bytes = Convert.FromBase64String(row.Base64Photo);
                    using (var ms = new MemoryStream(bytes)) {
                        match.Photo = Image.FromStream(ms);
                    }
                }

                break;
            }

            return match;
        }

        public IEnumerable<Machine> GetAll()
        {
            var machines = new List<Machine>();

            foreach (MachinesDataSet.MachinesRow row in DataSet.Machines.Rows) {
                var mc = new Machine {
                    Id = row.Id,
                    Name = row.Name,
                    ComPort = row.ComPort,
                    MachineControlId = row.MachineControlId
                };

                if (!string.IsNullOrWhiteSpace(row.Base64Photo))
                {
                    var bytes = Convert.FromBase64String(row.Base64Photo);
                    using (var ms = new MemoryStream(bytes))
                    {
                        mc.Photo = Image.FromStream(ms);
                    }
                }

                machines.Add(mc);
            }

            return machines;
        }

        public void AddToFavourites(Machine machine, int employeeId)
        {
            MachinesDataSet.FavouriteMachinesRow row = DataSet.FavouriteMachines.NewFavouriteMachinesRow();
            row.EmployeeId = employeeId;
            row.MachineId = machine.Id;

            DataSet.FavouriteMachines.AddFavouriteMachinesRow(row);
        }

        public void RemoveFromFavourites(Machine machine, int employeeId)
        {
            var row =
                DataSet.FavouriteMachines.SingleOrDefault(r => r.MachineId == machine.Id && r.EmployeeId == employeeId);

            DataSet.FavouriteMachines.RemoveFavouriteMachinesRow(row);
        }

        public bool IsFavourite(Machine machine, int employeeId)
        {
            var row =
                DataSet.FavouriteMachines.SingleOrDefault(r => r.MachineId == machine.Id && r.EmployeeId == employeeId);

            return row != null;
        }

        public IEnumerable<Machine> GetFavouriteMachines(int employeeId)
        {
            var favouriteMachines = new List<Machine>();

            foreach (MachinesDataSet.FavouriteMachinesRow row in DataSet.FavouriteMachines.Rows) {
                if (row.EmployeeId != employeeId) {
                    continue;
                }
                var machine = GetById(row.MachineId);
                favouriteMachines.Add(machine);
            }

            return favouriteMachines;
        }

        public void Insert(Machine machine)
        {
            MachinesDataSet.MachinesRow rowToInsert = DataSet.Machines.NewMachinesRow();
            rowToInsert.Name = machine.Name;
            rowToInsert.ComPort = machine.ComPort;
            rowToInsert.MachineControlId = machine.MachineControlId;

            if (machine.Photo == null) {
                rowToInsert.Base64Photo = null;
            }
            else {
                var resizedPhoto = ResizeMachinePhotoToStandardResolution(machine.Photo);
                using (var ms = new MemoryStream()) {
                    resizedPhoto.Save(ms, ImageFormat.Jpeg);
                    
                    rowToInsert.Base64Photo = Convert.ToBase64String(ms.ToArray());
                }
            }

            DataSet.Machines.AddMachinesRow(rowToInsert);
        }

        public void Delete(int id)
        {
            MachinesDataSet.MachinesRow rowToDelete = DataSet.Machines.SingleOrDefault(m => m.Id == id);

            if (rowToDelete == null) {
                throw new KeyNotFoundException("Unable to find machine with an ID value of " + id);
            }

            DataSet.Machines.RemoveMachinesRow(rowToDelete);
        }

        public void Update(Machine machine)
        {
            MachinesDataSet.MachinesRow rowToUpdate = DataSet.Machines.SingleOrDefault(m => m.Id == machine.Id);

            if (rowToUpdate == null) {
                throw new KeyNotFoundException("Unable to find machine with an ID value of " + machine.Id);
            }

            rowToUpdate.Name = machine.Name;
            rowToUpdate.ComPort = machine.ComPort;
            rowToUpdate.MachineControlId = machine.MachineControlId;

            if (machine.Photo == null)
            {
                rowToUpdate.Base64Photo = null;
            }
            else
            {
                var resizedPhoto = ResizeMachinePhotoToStandardResolution(machine.Photo);
                using (var ms = new MemoryStream())
                {
                    resizedPhoto.Save(ms, ImageFormat.Jpeg);

                    rowToUpdate.Base64Photo = Convert.ToBase64String(ms.ToArray());
                }
            }

        }

        private Image ResizeMachinePhotoToStandardResolution(Image image)
        {
            double ratioX = 640.0d / image.Width;
            double ratioY = 480.0d / image.Height;

            double ratio = ratioX < ratioY ? ratioX : ratioY;

            int newHeight = Convert.ToInt32(image.Height * ratio);
            int newWidth = Convert.ToInt32(image.Width * ratio);

            var destRect = new Rectangle(0, 0, newWidth, newHeight);
            var destImage = new Bitmap(newWidth, newHeight);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

    }
}