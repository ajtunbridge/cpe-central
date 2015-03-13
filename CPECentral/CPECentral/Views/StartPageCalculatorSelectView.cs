#region Using directives

using System.Windows.Forms;

#endregion

namespace CPECentral.Views
{
    public partial class StartPageCalculatorSelectView : UserControl
    {
        private const string TriangleSolver = "Triangle solver";
        private const string HexagonSolver = "Hexagon solver";

        private StartPageCalculatorTriangleView _triangleSolverView;
        private StartPageCalculatorHexagonView _hexagonSolverView;

        public StartPageCalculatorSelectView()
        {
            InitializeComponent();

            optionsComboBox.Items.AddRange(new[] {
                TriangleSolver,
                HexagonSolver
            });

            optionsComboBox.SelectedIndex = 0;
        }

        private void optionsComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            foreach (Control c in calculatorPanel.Controls) {
                c.Visible = false;    
            }

            switch ((string)optionsComboBox.SelectedItem) {
                case TriangleSolver:
                    if (_triangleSolverView == null) {
                        _triangleSolverView = new StartPageCalculatorTriangleView();
                        _triangleSolverView.Dock = DockStyle.Fill;
                        calculatorPanel.Controls.Add(_triangleSolverView);
                    }
                    _triangleSolverView.Visible = true;
                    _triangleSolverView.BringToFront();
                    break;
                case HexagonSolver:
                    if (_hexagonSolverView == null) {
                        _hexagonSolverView = new StartPageCalculatorHexagonView();
                        _hexagonSolverView.Dock = DockStyle.Fill;
                        calculatorPanel.Controls.Add(_hexagonSolverView);
                    }
                    _hexagonSolverView.Visible = true;
                    _hexagonSolverView.BringToFront();
                    break;
            }
        }
    }
}