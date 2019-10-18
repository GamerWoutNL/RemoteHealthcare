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
            this.vRHandler = vRHandler;
        }

       

        /// <summary>
        /// Rotation should be set to 0.
        /// </summary>
        /// <returns></returns>
        public List<Route> GetRouteStart()
        {
            double level0 = 22;
            double levelmin1 = 14;
            List<Route> routes = new List<Route>();
            //Step 0, start position
            routes.Add(new Route(new VRPoint3D(-17.59, level0, -13.40), new VRPoint3D(-3, 0, -3), 1));


            //Step 1, route to crossing 1, level 0:
            routes.Add(new Route(new VRPoint3D(-87, level0, -13.40), new VRPoint3D(0,0,0), 1));


            //Step 2, route to lower level, level -1:
            routes.Add(new Route(new VRPoint3D(-114.0, levelmin1, -13.40), new VRPoint3D(0, 0.0, 0), 0.5));
            routes.Add(new Route(new VRPoint3D(-116.5, levelmin1, -13.40), new VRPoint3D(10, 0.0, 10), 0.5));


            //Step 3, route to point slope route, level -1:
            routes.Add(new Route(new VRPoint3D(-128.29, levelmin1, 9.33), new VRPoint3D(0, 0.0, 3), 1));

            //Step 4, route forwaring, level -1:
            routes.Add(new Route(new VRPoint3D(-128.29, levelmin1, 71.10), new VRPoint3D(0, 0.0, 3), 1));
            routes.Add(new Route(new VRPoint3D(-118, levelmin1, 71.10), new VRPoint3D(0, 0, 3), 1));

            //Step 5, upwards again, level 0:
            routes.Add(new Route(new VRPoint3D(-91, level0, 71.10), new VRPoint3D(0, 0, 3), 1));

            //Step 6, to the alley, level 0:
            routes.Add(new Route(new VRPoint3D(-76.02, level0, 71.10), new VRPoint3D(0,0,-15), 1));
            routes.Add(new Route(new VRPoint3D(-76.02, level0, 49.00), new VRPoint3D(0, 0, -10), 1));
            routes.Add(new Route(new VRPoint3D(-73.02, level0, 49.00), new VRPoint3D(0, 0, 0), 1));


            //Step 7, through the alley, level 0:
            routes.Add(new Route(new VRPoint3D(39.70, level0, 49.00), new VRPoint3D(0, 0, 0), 1));
            routes.Add(new Route(new VRPoint3D(41.52, level0, 44.00), new VRPoint3D(0, 0, -15), 1));
            routes.Add(new Route(new VRPoint3D(41.52, level0, -63.19), new VRPoint3D(0, 0, -15), 1));
            routes.Add(new Route(new VRPoint3D(37.52, level0, -65.19), new VRPoint3D(0, 0, 0), 1));


            //Step 8, to water lower, level 0 to -1
            routes.Add(new Route(new VRPoint3D(26.43, level0, -65), new VRPoint3D(0, 0, 0), 1));
            routes.Add(new Route(new VRPoint3D(19.92, levelmin1, -65), new VRPoint3D(0, 0, 0), 1));
            routes.Add(new Route(new VRPoint3D(19.92, levelmin1, -67.445), new VRPoint3D(0, 0, 0), 1));
            routes.Add(new Route(new VRPoint3D(0.09, levelmin1, -67.11), new VRPoint3D(0, 0, 0), 1));

            //Step 9, to upper, level 0
            routes.Add(new Route(new VRPoint3D(-8.92, level0, -67.11), new VRPoint3D(0, 0, 0), 1));
            routes.Add(new Route(new VRPoint3D(-8.92, level0, -65.36), new VRPoint3D(0, 0, 0), 1));
            routes.Add(new Route(new VRPoint3D(-16.33, level0, -65.36), new VRPoint3D(0, 0, 0), 1));

            return routes;
        } 
       
    }
}
