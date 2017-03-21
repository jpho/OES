using System;

namespace OrderEntrySystem
{
    public class EntityColumnAttribute : Attribute
    {
        public EntityColumnAttribute(int sequence, int width)
            : this(string.Empty, sequence, width)
        {
            
            this.Sequence = sequence;
            this.Width = width;
        }

        public EntityColumnAttribute(string description, int sequence, int width)            
        {
           
            this.Description = description;
            
        }

        public ControlType ControlType { get; set; }

        public string Description { get; set; }

        public int Sequence { get; set; }

        public int Width { get; set; }
    }
}
