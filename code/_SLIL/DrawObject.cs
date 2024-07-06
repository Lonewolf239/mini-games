namespace minigames._SLIL
{
    public class DrawObject
    {
        public double Distance { get; set; }
        public int ObjectID { get; set; }
        public int EnemyType { get; set; }

        public DrawObject(double distance, int objectID, int enemyType = -1)
        {
            Distance = distance;
            ObjectID = objectID;
            EnemyType = enemyType;
        }
    }
}