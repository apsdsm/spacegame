using DataHelpers.Interfaces;

namespace SpaceGame.Importers
{
    public class WaveDataImporter : IImporter<WaveData>
    {
        public void Import (WaveData asset, ReadBundle readBundle)
        {
            asset.waves = new WaveData.Wave[readBundle.validatedNodes.Count];

            for (int i = 0; i < readBundle.validatedNodes.Count; i++)
            {
                asset.waves[0] = new WaveData.Wave();
                asset.waves[0].saucers = readBundle.validatedNodes[i].AsInt32("Saucers");
                asset.waves[0].time = readBundle.validatedNodes[i].AsInt32("Time");
            }
        }
    }
}