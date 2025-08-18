using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClientDashboardAPI.Models
{
    public class Client
    {

        [Key]
        public int Id { get; set; }
        public bool Active { get; set; }
        public string? Name { get; set; }
        public List<PhoneNumber>? PhoneNumbers { get; set; }

        /// <summary>
        /// Flavor Text Variables
        /// </summary>
        /// <value></value>
        public string? Company { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}