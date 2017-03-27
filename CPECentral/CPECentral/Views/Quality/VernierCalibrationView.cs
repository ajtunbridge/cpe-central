using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;

namespace CPECentral.Views.Quality
{
    public partial class VernierCalibrationView : ViewBase
    {
        private Gauge _gauge;
        private double _m1, _m2, _m3, _m4;

        private void VernierCalibrationView_Load(object sender, EventArgs e)
        {

        }

        public VernierCalibrationView()
        {
            InitializeComponent();
        }


        public double ExtM1Deviation => CalculateDeviation(externalM1NumUpDown.Value, _m1);

        public double ExtM2Deviation => CalculateDeviation(externalM2NumUpDown.Value, _m2);

        public double ExtM3Deviation => CalculateDeviation(externalM3NumUpDown.Value, _m3);

        public double ExtM4Deviation => CalculateDeviation(externalM4NumUpDown.Value, _m4);

        public double IntM1Deviation => CalculateDeviation(internalM1NumUpDown.Value, _m1);

        public double IntM2Deviation => CalculateDeviation(internalM2NumUpDown.Value, _m2);

        public double IntM3Deviation => CalculateDeviation(internalM3NumUpDown.Value, _m3);

        public double IntM4Deviation => CalculateDeviation(internalM4NumUpDown.Value, _m4);

        private void m1_ValueChanged(object sender, EventArgs e)
        {
            var numUpDown = sender as NumericUpDown;

            var maxVal = _m1 + 0.02;
            var minVal = _m1 - 0.02;

            ColorizeBasedOnValue(numUpDown, minVal, maxVal);
        }

        private void m2_ValueChanged(object sender, EventArgs e)
        {
            var numUpDown = sender as NumericUpDown;

            var maxVal = _m2 + 0.02;
            var minVal = _m2 - 0.02;

            ColorizeBasedOnValue(numUpDown, minVal, maxVal);
        }

        private void m3_ValueChanged(object sender, EventArgs e)
        {
            var numUpDown = sender as NumericUpDown;

            var maxVal = _m3 + 0.02;
            var minVal = _m3 - 0.02;

            ColorizeBasedOnValue(numUpDown, minVal, maxVal);
        }

        private void m4_ValueChanged(object sender, EventArgs e)
        {
            var numUpDown = sender as NumericUpDown;

            var maxVal = _m4 + 0.02;
            var minVal = _m4 - 0.02;

            ColorizeBasedOnValue(numUpDown, minVal, maxVal);
        }

        public void SetGauge(Gauge gauge)
        {
            _gauge = gauge;

            CalculateMeasurementSizes();

            externalM1Label.Text = $"{_m1:##.000} mm";
            externalM2Label.Text = $"{_m2:##.000} mm";
            externalM3Label.Text = $"{_m3:##.000} mm";
            externalM4Label.Text = $"{_m4:##.000} mm";

            externalM1NumUpDown.Value = (decimal)_m1;
            externalM2NumUpDown.Value = (decimal)_m2;
            externalM3NumUpDown.Value = (decimal)_m3;
            externalM4NumUpDown.Value = (decimal)_m4;

            internalM1Label.Text = $"{_m1:##.000} mm";
            internalM2Label.Text = $"{_m2:##.000} mm";
            internalM3Label.Text = $"{_m3:##.000} mm";
            internalM4Label.Text = $"{_m4:##.000} mm";

            internalM1NumUpDown.Value = (decimal)_m1;
            internalM2NumUpDown.Value = (decimal)_m2;
            internalM3NumUpDown.Value = (decimal)_m3;
            internalM4NumUpDown.Value = (decimal)_m4;
        }

        private void finishedButton_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void CalculateMeasurementSizes()
        {
            if (_gauge.SizeRangeMin == null || _gauge.SizeRangeMax == null)
            {
                throw new InvalidOperationException("The size range has not been set for this vernier");
            }

            var range = _gauge.SizeRangeMax.Value - _gauge.SizeRangeMin.Value;

            _m1 = (range*0.01) + _gauge.SizeRangeMin.Value;
            _m2 = (range*0.15) + _gauge.SizeRangeMin.Value;
            _m3 = (range*0.5) + _gauge.SizeRangeMin.Value;
            _m4 = (range*0.95) + _gauge.SizeRangeMin.Value;
        }

        private void ColorizeBasedOnValue(NumericUpDown numUpDown, double minVal, double maxVal)
        {
            var value = Convert.ToDouble(numUpDown.Value);

            if (value > maxVal || value < minVal)
            {
                numUpDown.ForeColor = Color.Red;
            }
            else
            {
                numUpDown.ForeColor = Color.Green;
            }
        }

        private double CalculateDeviation(decimal actual, double expected)
        {
            var deviation = (double)actual - expected;

            return deviation;
        }
    }
}
