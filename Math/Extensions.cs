namespace IoBTMessage.Models;

using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;




static public class GeoMath
{

    public static HighResOffset HighResOffset { get; set; } = new HighResOffset();

    public static double toDouble(this string Value)
    {
        if (Value == null)
        {
            return 0;
        }
        else
        {
            double OutVal;
            double.TryParse(Value, out OutVal);

            if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
            {
                return 0;
            }
            return OutVal;
        }
    }

    public static int toInteger(this string Value)
    {
        if (Value == null)
        {
            return 0;
        }
        else
        {
            int OutVal;
            if (int.TryParse(Value, out OutVal))
            {
                return OutVal;
            }
            return 0;
        }
    }


    static public IPosition asCoord(this Feature<Point> point)
    {
        return point.Geometry.Coordinates;
    }

    static public double asLat(this Feature<Point> point)
    {
        return point.Geometry.Coordinates.Latitude;
    }


    static public double asLng(this Feature<Point> point)
    {
        return point.Geometry.Coordinates.Longitude;
    }

    static public Feature point(this ILocation obj)
    {
        var loc = new double[] { obj.lng, obj.lat };
        return Turf.Point(loc);
    }
    static public double distance(this ILocation obj1, ILocation obj2, string units = "kilometers")
    {
        return Turf.Distance(obj1.point(), obj2.point(), units);
    }

    static public double bearing(this ILocation obj1, ILocation obj2, string units = "kilometers")
    {
        return Turf.Bearing(obj1.point(), obj2.point());
    }

    static public Feature midpoint(this ILocation obj1, ILocation obj2)
    {
        return Turf.MidPoint(obj1.point(), obj2.point());
    }

    static public Feature destination(this ILocation obj, double distance, double bearing)
    {
        return Turf.Destination(obj.point(), distance, bearing);
    }

    static public List<double> toLatLng(this Feature obj)
    {
        var coord = Turf.GetCoord(obj);
        return coord;
    }

    static public List<Feature> intersection(this UDTO_Observation obj, UDTO_Observation target)
    {

        var list = new List<Feature>();

        // https://www.mathsisfun.com/algebra/trig-cosine-law.html

        // c2 = a2 + b2 − 2ab cos(C)

        var d = obj.distance(target);
        var r1 = target.range;
        var r2 = obj.range;
        if (d > r1 + r2)
        {
            return list;
        }

        var cosang = (r1 * r1 - r2 * r2 - d * d) / (-2.0 * r2 * d);
        var ang = obj.toDeg(Math.Acos(cosang));

        // 1  is right in KM
        //console.log(d)

        var brg = obj.bearing(target);

        var b1 = brg + ang;
        var pt1 = obj.destination(r2, b1);
        list.Add(pt1);

        var b2 = brg - ang;
        var pt2 = obj.destination(r2, b2);
        list.Add(pt2);

        return list;
    }

    static public Location computeGeoLocation(this HighResPosition pos, Location source)
    {
        var dist = Math.Sqrt(pos.xLoc * pos.xLoc + pos.zLoc * pos.zLoc);
        var brg = Math.Atan2(pos.xLoc, pos.zLoc);
        var feature = source.destination(dist, source.toDeg(brg));
        var loc = Turf.GetCoord(feature.Geometry);

        var result = new Location()
        {
            lat = loc[1],
            lng = loc[0],
            alt = source.alt + pos.yLoc + HighResOffset.yLoc,
        };

        return result;
    }

    static public HighResPosition computeHiresLocation(this Location source, Location target, string units = "kilometers")
    {
        var dist = source.distance(target);
        var brg = source.bearing(target);
        var rad = brg * Math.PI / 180;
        var result = new HighResPosition()
        {
            units = units,
            xLoc = dist * Math.Sin(rad),
            yLoc = target.alt - source.alt - HighResOffset.yLoc,
            zLoc = dist * Math.Cos(rad),
            yAng = brg
        };

        return result;
    }

    static public Location computeGeoLocation(this Location source, HighResPosition target)
    {
        var result = target.computeGeoLocation(source);
        return result;
    }
}
