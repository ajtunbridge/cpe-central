using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Messages;
using CPECentral.Properties;
using NcCommunicator.Data;
using NcCommunicator.Data.Model;

namespace CPECentral.Views
{
    public partial class MachineView : UserControl
    {
        private Machine _machine;
        private bool _isFavourite;

        public MachineView()
        {
            InitializeComponent();
        }

        public Machine Machine
        {
            get { return _machine; }
            set
            {
                _machine = value;
                DisplayMachineInfo();
            }
        }

        private void DisplayMachineInfo()
        {
            if (_machine == null) {
                // TODO: handle this shit
                return;
            }

            machineNameLabel.Text = "Send to " + _machine.Name + " on " + _machine.ComPort;

            pictureBox1.Image = _machine.Photo ?? Resources.NoMachineImageAvailable;

            _isFavourite = new NcUnitOfWork().Machines.IsFavourite(_machine, Session.CurrentEmployee.Id);

            toggleFavouritePictureBox.Image = _isFavourite ? Resources.FavouriteMachineIcon_16x16 : Resources.NotFavouriteMachineIcon_16x16;
        }

        private void MachineView_SizeChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            machineTransferQueuePictureBox.Image = Resources.MachineTransferQueueIconHighlighted_16x16;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            machineTransferQueuePictureBox.Image = Resources.MachineTransferQueueIcon_16x16;
        }

        private void toggleFavouritePictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_isFavourite) {
                toggleFavouritePictureBox.Image = Resources.FavouriteMachineIconHighlighted_16x16;
            }
            else {
                toggleFavouritePictureBox.Image = Resources.NotFavouriteMachineIconHighlighted_16x16;
            }
        }

        private void toggleFavouritePictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_isFavourite)
            {
                toggleFavouritePictureBox.Image = Resources.FavouriteMachineIcon_16x16;
            }
            else
            {
                toggleFavouritePictureBox.Image = Resources.NotFavouriteMachineIcon_16x16;
            }
        }

        private void toggleFavouritePictureBox_Click(object sender, EventArgs e)
        {
            _isFavourite = !_isFavourite;

            using (var nc = new NcUnitOfWork()) {
                if (!_isFavourite) {
                    nc.Machines.RemoveFromFavourites(_machine, Session.CurrentEmployee.Id);
                }
                else {
                    nc.Machines.AddToFavourites(_machine, Session.CurrentEmployee.Id);
                }
                nc.Commit();
            }

            toggleFavouritePictureBox.Image = _isFavourite ? Resources.FavouriteMachineIcon_16x16 : Resources.NotFavouriteMachineIcon_16x16;

            Session.MessageBus.Publish(new FavouriteMachinesChangedMessage());
        }
    }
}
