using System;
using System.Collections.Generic;
using System.Text;

namespace _4.BorderControl
{
    public class Robot : IControlable
    {
        private string model;
        private string id;

        public Robot(string m, string id)
        {
            this.Model = m;
            this.Id = id;
        }

        public string Model
        {
            get => this.model;
            set
            {
                this.model = value;
            }
        }

        public string Id
        {
            get => this.id;
            set
            {
                this.id = value;
            }
        }
    }
}
