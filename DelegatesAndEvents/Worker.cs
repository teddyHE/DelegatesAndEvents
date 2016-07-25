using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //it is better if you put your delegates above the class 
    //that it is using them.
    public delegate int WorkPerformedHandler(int hours, WorkType workType);

    class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public void Dowork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                //Raise event for workperformed
                OnWorkPerformed(i + 1, workType);
            }
            //Raise event for work completed
            OnWorkCompleted();
        }

        //It is a best practice tu put "On" + Name of the event
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //if(WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            var del = WorkPerformed as WorkPerformedHandler;
            if (del != null)
            {
                del(hours, workType);
            }
        }

        protected virtual void OnWorkCompleted()
        {
            //if(WorkCompleted != null)
            //{
            //    WorkCompleted(this, EventArgs.Empty);
            //}

            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
