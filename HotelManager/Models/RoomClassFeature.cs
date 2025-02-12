namespace HotelManager.Models
{
    public class RoomClassFeature
    {
        public int RoomClassId { get; set; }
        public RoomClass RoomClass { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
