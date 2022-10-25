using System.Diagnostics;

namespace Dungeon_Crawl.src.Core.View
{
    internal class Camera
    {
        private const int _width = 81;
        private const int _height = 25;

        public List<string> GetView(Position centralPosition, Map map)
        {
            var mapView = map.RenderMap();

            var startHeight = Math.Max(0, centralPosition.Y - (_height - 1) / 2);
            var endHeight = Math.Min(startHeight + _height - 1, map.Height - 1);

            Debug.Assert(startHeight < endHeight, "początkowa wysokość powinna być mniejsz od końcowej");

            var startWidth = Math.Max(0, centralPosition.X - (_width - 1) / 2);
            var endWidth = Math.Min(startWidth + _width - 1, map.Width - 1);

            Debug.Assert(startWidth < endWidth);

            var cameraView = new List<string>();
            var verticalRange = mapView.ToArray()[startHeight..endHeight];
            foreach (var line in verticalRange)
            {
                cameraView.Add(line[startWidth..endWidth]);
            }
            return cameraView;
        }
    }
}
