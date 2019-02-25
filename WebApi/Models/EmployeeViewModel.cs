﻿namespace WebApi.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public string CreatedOn { get; set; }
        public string DeletedOn { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Name { get; set; }
        public string LastLogin { get; set; }
        public string Password { get; set; }
        public int PortalId { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
        public string Telephone { get; set; }
        public string UpdatedOn { get; set; }
        public string Username { get; set; }
    }
}