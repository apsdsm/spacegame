using UnityEditor;
using SpaceGame.Importers;
using SpaceGame.Validators;

namespace SpaceGame.PostProcessors
{
    public class WaveDataPostProcessor : AssetPostprocessor
    {

        private static void OnPostprocessAllAssets(string[] importedAssets,
                                                   string[] deletedAssets,
                                                   string[] movedAssets,
                                                   string[] movedFromPath)
        {
            foreach (string asset in importedAssets)
            {
                if (asset.Contains(".wavedata."))
                {
                    PostprocessorHelper.Import<WaveData, WaveDataImporter, WaveDataValidator>(asset);
                }
            }
        }
    }
}
