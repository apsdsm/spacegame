namespace SpaceGame.Tests.Integration.ShipTests
{
    [IntegrationTest.DynamicTest( "ShipTests" )]
    class it_gets_the_object_position : ship_test
    {
        void Test ()
        {
            AssertThat( ship.GetPosition() == ship_object.transform.position );
        }
    }
}

