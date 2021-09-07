using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DocumentedAPIExample
{
    public class TodoItem
    {

        public int ID { get; set; }

        /// <summary>
        /// Indicates if the todo item was completed
        /// </summary>
        [DefaultValue(false)]
        public Boolean Completed  { get; set; }

        /// <summary>
        /// The todo item description
        /// </summary>
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public String  Text { get; set; }
       
    }
}
