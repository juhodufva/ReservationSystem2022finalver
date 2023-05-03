namespace ReservationSystem2022.Models

{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LoginDate { get; set; }
    
      
    }

    public class UserDTO
    {
        
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LoginDate { get; set; }
     
    }
}
