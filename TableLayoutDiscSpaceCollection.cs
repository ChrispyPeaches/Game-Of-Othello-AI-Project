using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfOthelloAssignment
{
    public class TableLayoutDiscSpaceCollection : Control.ControlCollection
    {
        private TableLayoutPanel _container;

        //
        // Summary:
        //     Gets the parent System.Windows.Forms.TableLayoutPanel that contains the controls
        //     in the collection.
        //
        // Returns:
        //     The System.Windows.Forms.TableLayoutPanel that contains the controls in the current
        //     collection.
        public TableLayoutPanel Container => _container;

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Forms.TableLayoutControlCollection
        //     class.
        //
        // Parameters:
        //   container:
        //     The System.Windows.Forms.TableLayoutPanel control that contains the control collection.
        public TableLayoutDiscSpaceCollection(TableLayoutPanel container)
            : base(container)
        {
            _container = container;
        }

        //
        // Summary:
        //     Adds the specified control to the collection and positions it at the specified
        //     cell.
        //
        // Parameters:
        //   control:
        //     The control to add.
        //
        //   column:
        //     The column in which control will be placed.
        //
        //   row:
        //     The row in which control will be placed.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     Either column or row is less than -1.
        public virtual void Add(DiscSpace control, int column, int row)
        {
            base.Add(control);
            _container.SetColumn(control, column);
            _container.SetRow(control, row);
        }
    }
}
