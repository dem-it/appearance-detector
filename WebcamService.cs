using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppearanceDetector;

internal static class WebcamService
{
    internal static FilterInfoCollection DiscoverWebcams()
    {
        return new FilterInfoCollection(FilterCategory.VideoInputDevice);
    }
}
