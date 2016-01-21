using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame.Tests.Integration.SizeReporterTests
{
    [IntegrationTest.DynamicTest( "SizeReporterTests" )]
    class it_reports_the_size_of_an_objects_sphere_collider : size_reporter_test
    {
        void Test ()
        {
            float sphereRadius = sphere_collider.radius;
            float reportedRadius = size_reporter.GetSize();

            AssertThat( sphereRadius == reportedRadius, "Reporter did not return correct radius" );
        }
    }
}
