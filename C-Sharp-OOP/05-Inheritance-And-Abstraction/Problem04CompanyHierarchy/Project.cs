using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem04CompanyHierarchy
{
    public enum State
    {
        open,
        closed,
    }

    class Project
    {
        private string projectName;
        private DateTime startDate;
        private string details;
        private State state;

        public Project(string projectName, DateTime startDate, string details, State state) 
        {
            this.ProjectName = projectName;
            this.StartDate = startDate;
            this.Details = details;
            this.state = state;
        }
        public string ProjectName 
        {
            get { return this.projectName; }
            set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The project name cannot be empty and must be at least 3 characters!");
                }
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\s]+$") || !char.IsUpper(value, 0))
                {
                    throw new FormatException("The project name must be only latin letters and start with capital letter!");
                }
                this.projectName = value; }
        }

        public DateTime StartDate 
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        public string Details 
        {
            get { return this.details; }
            set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Details cannot be empty and must be at least 3 characters!");
                }
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\s]+$") || !char.IsUpper(value, 0))
                {
                    throw new FormatException("Details must be only latin letters, spaces and start with capital letter!");
                }
                this.details = value; }
        }

        //public State State { get; set; }

        public void CloseProject()
        {
            this.state = State.closed;
        }

        public override string ToString()
        {
            return string.Format("Project: {0}; Start date: {1}; Details: {2}; State: {3}", this.projectName, this.startDate.ToString("d"), this.details, this.state);
        }
    }
}
