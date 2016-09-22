using DataHelpers.Interfaces;
using System;

namespace SpaceGame.Importers
{
    public class WaveDataImporter : IImporter<WaveData>
    {
        public void Import (WaveData asset, ReadBundle readBundle)
        {
            asset.startTime =  Convert.ToInt32(readBundle.vars["startTime"]);

            asset.waves = new WaveData.Wave[readBundle.validatedNodes.Count];

            for (int i = 0; i < readBundle.validatedNodes.Count; i++)
            {
                asset.waves[i] = new WaveData.Wave();
                asset.waves[i].saucers = readBundle.validatedNodes[i].AsInt32("Saucers");
                asset.waves[i].time = readBundle.validatedNodes[i].AsInt32("Time");
            }
        }
    }
}