using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone2
{
    class Task
    {
        private string teamMemberName;
        private string desc;
        private DateTime dueDate;
        private bool isCompleted;

        public string TeamMemberName { get { return teamMemberName; } set { teamMemberName = value; } }
        public string Desc { get { return desc; } set { desc = value; } }
        public DateTime DueDate { get { return dueDate; } set { dueDate = value; } }
        public bool IsCompleted { get { return isCompleted; } set { isCompleted = value; } }

        public Task(string _memberName, string _desc, string _dueDate, bool _isCompleted = false)
        {
            teamMemberName = _memberName;
            desc = _desc;
            dueDate = DateTime.Parse(_dueDate);
            isCompleted = _isCompleted;
        }
        public override string ToString()
        {
            return $"\tTask: {desc}\n\tDue:\t\t\t{dueDate.ToShortDateString()}\n\tCompleted?\t\t{isCompleted}\n\tAssigned Member:\t{teamMemberName}";
        }
        public void SetComplete() 
        {
            isCompleted = true;
        }

    }
}
