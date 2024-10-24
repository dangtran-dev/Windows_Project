using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project
{
    public class IsExpanderExpaned : INotifyPropertyChanged
    {
        private bool _isExpanderExpanded;
        private string _toggleText;

        public bool isExpanderExpanded
        {
            get { return _isExpanderExpanded; }
            set
            {
                _isExpanderExpanded = value;
                toggleText = _isExpanderExpanded ? "Thu gọn" : "Mở rộng";
            }
        }
        public string toggleText
        {
            get { return _toggleText; }
            set
            {
                _toggleText = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
