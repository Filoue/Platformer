namespace Singletone
{
    public class ScoreLevelOne
    {
        private static ScoreLevelOne _instanceOne;

        public static ScoreLevelOne InstanceOne()
        {
            if (_instanceOne == null)
            {
                _instanceOne = new ScoreLevelOne();
            }
            return _instanceOne;
        }
        
        private ScoreLevelOne() {}
        
        public int ScorelvlOne;
    }
}