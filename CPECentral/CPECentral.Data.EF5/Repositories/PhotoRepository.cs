#region Using directives

using System;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public class PhotoRepository : RepositoryBase<Photo>
    {
        public PhotoRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Set(PartVersion partVersion, byte[] photoBytes)
        {
            string address = $"PartVersion:{partVersion.Id}";

            Set(address, photoBytes);
        }

        public void Set(Gauge gauge, byte[] photoBytes)
        {
            string address = $"Gauge:{gauge.Id}";

            Set(address, photoBytes);
        }

        private void Set(string address, byte[] photoBytes)
        {
            Photo record = GetPhotoByAddress(address);

            if (record == null)
            {
                record = new Photo
                {
                    Address = address,
                    Data = photoBytes
                };

                Add(record);
            }
            else
            {
                record.Data = photoBytes;

                Update(record);
            }
        }

        public byte[] GetByPartVersion(PartVersion partVersion)
        {
            string address = $"PartVersion:{partVersion.Id}";

            Photo entity = GetPhotoByAddress(address);

            return entity?.Data;
        }

        public byte[] GetByGauge(Gauge gauge)
        {
            string address = $"Gauge:{gauge.Id}";
            
            Photo entity = GetPhotoByAddress(address);

            return entity?.Data;
        }

        public void Delete(PartVersion partVersion)
        {
            string address = $"PartVersion:{partVersion.Id}";

            var record = GetPhotoByAddress(address);

            Delete(record);
        }

        public void Delete(Gauge gauge)
        {
            string address = $"Gauge:{gauge.Id}";

            var record = GetPhotoByAddress(address);

            Delete(record);
        }

        private Photo GetPhotoByAddress(string address)
        {
            return GetSet().SingleOrDefault(p => p.Address == address);
        }
    }
}