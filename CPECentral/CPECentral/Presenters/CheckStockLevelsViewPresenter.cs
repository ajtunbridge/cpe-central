#region Using directives

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CPECentral.CustomEventArgs;
using CPECentral.ViewModels;
using CPECentral.Views;
using Tricorn;

#endregion

namespace CPECentral.Presenters
{
    public class CheckStockLevelsViewPresenter
    {
        private readonly ICheckStockLevelsView _view;

        public CheckStockLevelsViewPresenter(ICheckStockLevelsView view)
        {
            _view = view;

            _view.PerformSearch += _view_PerformSearch;
        }

        private void _view_PerformSearch(object sender, StringEventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(e.Value);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = e.Result as List<CheckStockLevelsViewModel>;

            _view.DisplayResults(result);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var searchValue = (string) e.Argument;

            if (!searchValue.Contains("%")) {
                searchValue = "%" + searchValue + "%";
            }

            var modelItems = new List<CheckStockLevelsViewModel>();

            using (var tricorn = new TricornDataProvider()) {
                IOrderedEnumerable<Material> materials = tricorn.GetMaterials(searchValue).OrderBy(m => m.Name);

                foreach (Material material in materials) {
                    IEnumerable<MStock> batchesGreaterThanZero = tricorn.GetMStocks(material.Material_Reference)
                        .Where(b => b.Quantity_In_Stock > 0);

                    double? totalQuantity = 0;

                    var parent = new CheckStockLevelsViewModel(material.Name, null, null,
                        new List<CheckStockLevelsViewModel>());

                    if (!batchesGreaterThanZero.Any()) {
                        continue;
                    }

                    foreach (MStock batch in batchesGreaterThanZero) {
                        totalQuantity += batch.Quantity_In_Stock;
                        var child = new CheckStockLevelsViewModel(batch.Batch_Number, batch.Quantity_In_Stock.ToString(),
                            batch.Location, null);
                        parent.Children.Add(child);
                    }

                    parent.Quantity = totalQuantity.ToString();

                    modelItems.Add(parent);
                }
            }

            e.Result = modelItems;
        }
    }
}