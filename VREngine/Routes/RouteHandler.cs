using Sprint2VR.VR.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VREngine.Routes
{
    public class RouteHandler
    {
        public List<Route> routePath { get; set; }
        private VRHandler vRHandler;
        private const double downwardsPenalty = 0.5;
        private const double upwardsPenalty = 1.5;
        public int currentRoute { get; set; }
        public RouteHandler(VRHandler vRHandler)
        {
            routePath = new List<Route>();
            CreateRoutePath();
            this.vRHandler = vRHandler;
        }

        public void CreateRoutePath()
        {

            //Y-level 0 = 22.
            //Y-level -1 = 14.
            currentRoute = 0;
            //Step 1, route to crossing 1, level 0:
            routePath.Add(new Route(new VRPoint3D(-88, 22.00, -13.40), 1));

            //Step 2, route to lower level, level -1:
            routePath.Add(new Route(new VRPoint3D(-115.5, 14, -13.40), 0.5));
            routePath.Add(new Route(new VRPoint3D(-116, 14, -13.40), new VRPoint3D(0, 20, 0), 0.5));
            routePath.Add(new Route(new VRPoint3D(-116.5, 14, -13.40), new VRPoint3D(0, 40, 0), 0.5));
            routePath.Add(new Route(new VRPoint3D(-117, 14, -13.40), new VRPoint3D(0, 60, 0), 0.5));

            //Step 3, route to point slope route, level -1:
            routePath.Add(new Route(new VRPoint3D(-128.29, 14, 9.33), new VRPoint3D(0, 65, 0), 1));
            routePath.Add(new Route(new VRPoint3D(-128.29, 14, 10.33), new VRPoint3D(0, 75, 0), 1));
            routePath.Add(new Route(new VRPoint3D(-128.29, 14, 11.33), new VRPoint3D(0, 90, 0), 1));
           

            //Step 4, route to crossing after slope route, level -1:
            //routePath.Add(new Route(new VRPoint3D(-128.29, 14, 11.33), new VRPoint3D(0, 90, 0), 1));
            AddCurvedPath(new VRPoint3D(-128.29, 14, 13.33), new VRPoint3D(0, 90, 0), new VRPoint3D(-128.29, 14, 71.02), new VRPoint3D(0, 150, 0), 5.0);


        }

        public void AddCurvedPath(VRPoint3D start, VRPoint3D startRotation, VRPoint3D end, VRPoint3D endRotation, double stepSize)
        {
            VRPoint3D originalStart = new VRPoint3D(start.posx, start.posy, start.posz);
            VRPoint3D originalRotation = new VRPoint3D(startRotation.posx, startRotation.posy, startRotation.posz);
            while (!start.IsEqualTo(end))
            {
                //For values
                if (start.posx != end.posx)
                    start.posx += (end.posx - originalStart.posx) / stepSize;
                if (start.posy != end.posy)
                    start.posy += (end.posy - originalStart.posy) / stepSize;
                if (start.posz != end.posz)
                    start.posz += (end.posz - originalStart.posz) / stepSize;

                //For rotations
                if (startRotation.posy != endRotation.posy)
                    startRotation.posy += (endRotation.posy - originalRotation.posy) / stepSize;
                double resistancePenalty = 1;
                if (start.posy > end.posy)
                    resistancePenalty = downwardsPenalty;
                else if (start.posy < end.posy) resistancePenalty = upwardsPenalty;
                Console.WriteLine($"Rotation: {startRotation.posy} Position: {start.posx} - {start.posz}");
                Console.Read();
                routePath.Add(new Route(start, startRotation, resistancePenalty));
            }
        }

        public bool CheckDestinationReached(VRPoint3D vRPoint3D)
        {
            if (currentRoute < routePath.Count())
            {
                Route route = routePath[currentRoute];
                if (vRPoint3D.IsEqualTo(route.endPos))
                {
                    currentRoute++;
                    return true;
                }
            }
            return false;
        }
    }
}
