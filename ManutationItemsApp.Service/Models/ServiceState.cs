using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Service.Models
{
    public class ServiceState
    {
        private string _errorMessage;

        public bool IsValid { get; set; }
        public TypeOfServiceError TypeOfError { get; set; }
        public ServiceState()
        {
            IsValid = true;
            TypeOfError = TypeOfServiceError.Success;
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                IsValid = false;
                _errorMessage = value;
            }
        }
    }
}
