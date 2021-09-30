using Xamarin.Forms;

namespace HomeApp.Pages
{
    public partial class GridPage : ContentPage
    {
        public GridPage()
        {
            
            Grid grid = new Grid()
            {
                // Набор строк 
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                },

                // Набор столбцов
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                },
                
                ColumnSpacing = 20,
                RowSpacing = 20
            };

            //FillGridByCells(grid);
            //PopulateGrid(grid);
            MergeColumns(grid);
            Content = grid;
            
        
            
            
        }

        public void FillGridByCells(Grid grid)
        {
            // Добавление элементов по определенным позициям
            grid.Children.Add(new BoxView { Color = Color.FromRgb(250, 253, 255) }, 0 /* Позиция слева */, 0 /* Позиция сверху */);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(196, 232, 255) }, 0, 1);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(133, 207, 255) }, 0, 2);
 
            grid.Children.Add(new BoxView { Color = Color.FromRgb(87, 189, 255) }, 1, 0);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(43, 172, 255) }, 1, 1);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(23, 164, 255) }, 1, 2);
 
            grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 121, 199) }, 2, 0);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 76, 199) }, 2, 1);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 76, 199) }, 2, 2);
            /*
             * Обратите внимание: при инициализации RowDefinitions и ColumnDefinitions,
             * задавая высоту и ширину с помощью объекта GridLength, мы передаем первый параметр value = 1 для того,
             * чтобы указать, что доля данного столбца или строки от всего пространства будет составлять 1
             * (то есть он будет занимать пространство целиком).
             *
             * Соответственно, сколько столбцов/рядов мы в итоге передадим при генерации Grid-а,
             * именно такую часть от общего пространства будет каждый из них занимать
             * (пространство будет равномерно разделено между ними).
             */
        }
        
        /// <summary>
        ///  Заполнение лейаута
        /// </summary>
        public void PopulateGrid(Grid grid)
        {
            // Добавление элементов по определенным позициям
            grid.Children.Add(new BoxView { Color = Color.FromRgb(250, 253, 255) }, 0 /* Позиция слева */, 0 /* Позиция сверху */);
 
            // Сохраняем элемент перед добавлением, чтобы потом модифицировать
            var mergedRow = new BoxView { Color = Color.FromRgb(196, 232, 255) };
            // Добавляем в Grid
            grid.Children.Add(mergedRow, 0, 1);
            // Устанавливаем свойство ColumnSpan, чтобы расширить элемент на 3 позиции
            Grid.SetColumnSpan(mergedRow, 3);
 
            grid.Children.Add(new BoxView { Color = Color.FromRgb(133, 207, 255) }, 0, 2);
 
            grid.Children.Add(new BoxView { Color = Color.FromRgb(87, 189, 255) }, 1, 0);
            // grid.Children.Add(new BoxView { Color = Color.FromRgb(43, 172, 255) }, 1, 1);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(23, 164, 255) }, 1, 2);
 
            grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 121, 199) }, 2, 0);
            // grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 76, 199) }, 2, 1);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 76, 199) }, 2, 2);
        }
        
        /// <summary>
        ///  Заполнение лейаута
        /// </summary>
        public void MergeColumns(Grid grid)
        {
            // Добавляем элемент в начало левого ряда
            var leftMergedColumn = new BoxView { Color = Color.FromRgb(133, 207, 255) };
            grid.Children.Add(leftMergedColumn, 0, 0);
            // Растягиваем его на 3 позиции вниз
            Grid.SetRowSpan(leftMergedColumn, 3);
 
            // Заполняем средний ряд
            grid.Children.Add(new BoxView { Color = Color.FromRgb(87, 189, 255) }, 1, 0);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(43, 172, 255) }, 1, 1);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(23, 164, 255) }, 1, 2);
 
 
            // Добавляем элемент в начало правого ряда
            var rightMergedColumn = new BoxView { Color = Color.FromRgb(133, 207, 255) };
            grid.Children.Add(rightMergedColumn, 2, 0);
            // Растягиваем его на 3 позиции вниз
            Grid.SetRowSpan(rightMergedColumn, 3);
        }
    }
}