using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClientDashboardAPI.Models
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }

        private string _rawPhoneNumber;
        public string RawPhoneNumber => _rawPhoneNumber;
        private string _formattedNumber;
        [Required]
        public string FormattedNumber
        {
            get => _formattedNumber;
            set
            {
                _formattedNumber = value;
                _rawPhoneNumber = new string(value?.Where(char.IsDigit).ToArray() ?? Array.Empty<char>());
            }
        }

        [JsonIgnore]
        public Client? Client { get; set; }
    }
}