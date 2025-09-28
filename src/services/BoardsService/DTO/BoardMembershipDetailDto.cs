namespace BoardsService.DTO
{
    public class BoardMembershipDetailDto
    {
        public Guid BoardId { get; set; }

        public string BoardName { get; set; }

        public Guid UserId { get; set; }

        public DateTime JoiningDate { get; set; }

        public string TypeOfMembership { get; set; }

        //public BoardResponseDto BoardInfo { get; set; }
    }
}
