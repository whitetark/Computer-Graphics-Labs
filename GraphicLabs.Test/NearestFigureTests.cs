namespace GraphicLabs.Test
{
    public class NearestFigureTests
    {
        [Test]
        public void Sphere_And_Triangle()
        {
            // arrange
            var testSphere = new Sphere(new Point(0, 0, -10), 2);
            var testTriangle = new Triangle(new Point(1, 1, -15), new Point(5, 5, -11), new Point(0, 3, -2));
            
            var camera = new Camera(0, 0, 0, 0, 0, -1, 20, 20);
            var lightSource = new DirectionalLight() { Direction = new Vector(0, 0, -1) };
            var scene = new Scene(camera, lightSource);
            TracingLight tracingLight = new TracingLight();

            var expected = testSphere;

            int a = 11;
            int b = 8;
            
            scene.addFigure(testSphere);
            scene.addFigure(testTriangle);

            // act
            var result = tracingLight.FindNearest(scene, a, b);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void Sphere_And_Plane()
        {
            // arrange
            var testSphere = new Sphere(new Point(3, 3, -15), 2);
            var testPlane = new Plane(new Vector(0, 0, 1), new Point(0, 0, -7));
            
            var camera = new Camera(0, 0, 0, 0, 0, -1, 20, 20);
            var lightSource = new DirectionalLight() { Direction = new Vector(0, 0, -1) };
            var scene = new Scene(camera, lightSource);
            TracingLight tracingLight = new TracingLight();

            var expected = testPlane;

            int a = 10;
            int b = 10;
            
            scene.addFigure(testSphere);
            scene.addFigure(testPlane);
            

            // act
            var result = tracingLight.FindNearest(scene, a, b);

            // assert
            Assert.That(result, Is.EqualTo(expected));

        }
    }
}