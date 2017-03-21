using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderEntryEngine
{
    public class Category : IDataErrorInfo, IEntity, ILookupEntity
    {
        /// <summary>
        /// The property names to validate.
        /// </summary>
        private static readonly string[] PropertiesToValidate =
        {
            "Name"
        };

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsArchived { get; set; }

        public virtual ICollection<LaptopCategory> LaptopCategories { get; set; }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public bool IsValid
        {
            get
            {
                bool result = true;

                foreach (string s in Category.PropertiesToValidate)
                {
                    if (this.GetValidationError(s) != null)
                    {
                        result = false;
                        break;
                    }
                }

                return result;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                return this.GetValidationError(propertyName);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Gets the validation error for a specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property to test against.</param>
        /// <returns>The validation error.</returns>
        private string GetValidationError(string propertyName)
        {
            string result = null;

            switch (propertyName)
            {
                case "Name":
                    result = this.ValidateName();
                    break;
                default:
                    throw new Exception("Unexpected property was found to validate.");
            }

            return result;
        }

        private string ValidateName()
        {
            string result = null;

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                result = "Name is required.";
            }

            return result;
        }
    }
}