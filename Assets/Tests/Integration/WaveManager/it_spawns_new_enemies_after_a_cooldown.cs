namespace SpaceGame.Tests.Integration.WaveManagerTests
{
    [IntegrationTest.DynamicTest("WaveManagerTests")]
    class it_spawns_new_enemies_after_a_cooldown : test_case
    {
        public override void SetUp ()
        {
            base.SetUp();

            wave_manager.spawnCooldown = 0.5f;
            wave_manager.enemiesInWave = 1;
        }

        void TestEachFrame ()
        {
            if (TotalTime < 0.5f)
            {
                if (factory.createEnemyShipCalled > 0)
                {
                    Fail("created a ship during the cooldown period");
                }
            }
            else if (TotalTime > 0.5f)
            {
                if (factory.createEnemyShipCalled == 1)
                {
                    Pass();
                }
            }
        }
    }
}