using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grades;

namespace Games
{
    public abstract class GradeTracker : IGradeTracker
    {
        event EventHandler<NameChangeEventArgs> IGradeTracker.NameChanged
        {
            add
            {
//                throw new NotImplementedException();
            }
            
            remove
            {
//                throw new NotImplementedException();
            }
        }

        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();


        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name != value && NameChanged != null)
                {
                    if (String.IsNullOrEmpty(_name)) _name = "";
                    NameChangeEventArgs args = new NameChangeEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;
                    NameChanged(this, args);
                }
                _name = value;

            }
        }

        public event NameChangedDelegate NameChanged;
        protected string _name;
    }
}
