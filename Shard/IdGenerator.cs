namespace Shard
{
    public class IdGenerator
    {
        private readonly int _shardId;

        public IdGenerator(int shardId)
        {
            _shardId = shardId;
        }

        public long GenerateId(long localId)
        {
            return ((long)_shardId << 48) | localId;
        }
    }

}
