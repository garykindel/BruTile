﻿// Copyright (c) BruTile developers team. All rights reserved. See License.txt in the project root for license information.

using System;
using BruTile.Cache;
using BruTile.Web;
using System.Net.Http;

namespace BruTile.Predefined
{
    /// <summary>
    /// Known tile sources
    /// </summary>
    public enum KnownTileSource
    {
        OpenStreetMap,
        OpenCycleMap,
        OpenCycleMapTransport,
        BingAerial,
        BingHybrid,
        BingRoads,
        BingAerialStaging,
        BingHybridStaging,
        BingRoadsStaging,
        StamenToner,
        StamenTonerLite,
        StamenWatercolor,
        StamenTerrain,
        EsriWorldTopo,
        EsriWorldPhysical,
        EsriWorldShadedRelief,
        EsriWorldReferenceOverlay,
        EsriWorldTransportation,
        EsriWorldBoundariesAndPlaces,
        EsriWorldDarkGrayBase,        
        GoogleMap,        
        GoogleHybrid,
        GoogleSatellite,
        GoogleTerrain
        //MacrostratRaster
    }

    public static class KnownTileSources
    {
        private static readonly Attribution OpenStreetMapAttribution = new Attribution(
            "© OpenStreetMap contributors", "https://www.openstreetmap.org/copyright");

        /// <summary>
        /// Static factory method for known tile services
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="apiKey">An (optional) API key</param>
        /// <param name="persistentCache">A place to permanently store tiles (file of database)</param>
        /// <param name="tileFetcher">Option to override the web request</param>
        /// <returns>The tile source</returns>
        public static HttpTileSource Create(KnownTileSource source = KnownTileSource.OpenStreetMap, string apiKey = null,
            IPersistentCache<byte[]> persistentCache = null, Func<Uri, byte[]> tileFetcher = null, string appName=null)
        {
            switch (source)
            {
                //case KnownTileSource.MacrostratRaster:
                //    return new HttpTileSource(new GlobalSphericalMercator(),
                //    "https://macrostrat.org/map-raster/{z}/{x}/{y}/bedrock/lines/",
                //    new[] { "a", "b", "c" }, name: source.ToString(),
                //    persistentCache: persistentCache, tileFetcher: FetchGoogleTile);
                case KnownTileSource.GoogleMap:
                    return new HttpTileSource(new GlobalSphericalMercator(),
                            "http://mt{s}.google.com/vt/lyrs=m@130&hl=en&x={x}&y={y}&z={z}",
                            new[] { "0", "1", "2", "3" },
                            tileFetcher: FetchGoogleTile);

                case KnownTileSource.GoogleHybrid:
                    return new HttpTileSource(new GlobalSphericalMercator(),
                            "http://mt{s}.google.com/vt/lyrs=y@125&hl=en&x={x}&y={y}&z={z}",
                            new[] { "0", "1", "2", "3" },
                            tileFetcher: FetchGoogleTile);

                case KnownTileSource.GoogleTerrain:
                    return new HttpTileSource(new GlobalSphericalMercator(),
                            "http://mt{s}.google.com/vt/lyrs=t@125,r@130&hl=en&x={x}&y={y}&z={z}",
                            new[] { "0", "1", "2", "3" },
                            tileFetcher: FetchGoogleTile);

                case KnownTileSource.GoogleSatellite:
                    return new HttpTileSource(new GlobalSphericalMercator(),
                            "http://mt{s}.google.com/vt/lyrs=s@125&hl=en&x={x}&y={y}&z={z}",
                            new[] { "0", "1", "2", "3" },
                            tileFetcher: FetchGoogleTile);

                case KnownTileSource.OpenStreetMap:
                    return new HttpTileSource(new GlobalSphericalMercator(0, 18),
                        "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                        new[] {"a", "b", "c"}, name: source.ToString(),
                        persistentCache: persistentCache, tileFetcher: tileFetcher,
                        attribution: OpenStreetMapAttribution, appName: appName);
                case KnownTileSource.OpenCycleMap:
                    return new HttpTileSource(new GlobalSphericalMercator(0, 17),
                        "http://{s}.tile.opencyclemap.org/cycle/{z}/{x}/{y}.png",
                        new[] {"a", "b", "c"}, name: source.ToString(),
                        persistentCache: persistentCache, tileFetcher: tileFetcher,
                        attribution: OpenStreetMapAttribution, appName: appName);
                case KnownTileSource.OpenCycleMapTransport:
                    return new HttpTileSource(new GlobalSphericalMercator(0, 20),
                        "http://{s}.tile2.opencyclemap.org/transport/{z}/{x}/{y}.png",
                        new[] {"a", "b", "c"}, name: source.ToString(),
                        persistentCache: persistentCache, tileFetcher: tileFetcher,
                        attribution: OpenStreetMapAttribution, appName:appName);
                case KnownTileSource.BingAerial:
                    return new HttpTileSource(new GlobalSphericalMercator(1),
                        "http://t{s}.tiles.virtualearth.net/tiles/a{quadkey}.jpeg?g=517&token={k}",
                        new[] {"0", "1", "2", "3", "4", "5", "6", "7"}, apiKey, source.ToString(),
                        persistentCache, tileFetcher, new Attribution("© Microsoft"), appName);
                case KnownTileSource.BingHybrid:
                    return new HttpTileSource(new GlobalSphericalMercator(1),
                        "http://t{s}.tiles.virtualearth.net/tiles/h{quadkey}.jpeg?g=517&token={k}",
                        new[] {"0", "1", "2", "3", "4", "5", "6", "7"}, apiKey, source.ToString(),
                        persistentCache, tileFetcher, new Attribution("© Microsoft"), appName);
                case KnownTileSource.BingRoads:
                    return new HttpTileSource(new GlobalSphericalMercator(1),
                        "http://t{s}.tiles.virtualearth.net/tiles/r{quadkey}.jpeg?g=517&token={k}",
                        new[] {"0", "1", "2", "3", "4", "5", "6", "7"}, apiKey, source.ToString(),
                        persistentCache, tileFetcher, new Attribution("© Microsoft"), appName);
                case KnownTileSource.BingAerialStaging:
                    return new HttpTileSource(new GlobalSphericalMercator(1),
                        "http://t{s}.staging.tiles.virtualearth.net/tiles/a{quadkey}.jpeg?g=517&token={k}",
                        new[] {"0", "1", "2", "3", "4", "5", "6", "7"}, apiKey, source.ToString(),
                        persistentCache, tileFetcher, null, appName);
                case KnownTileSource.BingHybridStaging:
                    return new HttpTileSource(new GlobalSphericalMercator(1),
                        "http://t{s}.staging.tiles.virtualearth.net/tiles/h{quadkey}.jpeg?g=517&token={k}",
                        new[] {"0", "1", "2", "3", "4", "5", "6", "7"}, apiKey, source.ToString(),
                        persistentCache, tileFetcher, null, appName);
                case KnownTileSource.BingRoadsStaging:
                    return new HttpTileSource(new GlobalSphericalMercator(1),
                        "http://t{s}.staging.tiles.virtualearth.net/tiles/r{quadkey}.jpeg?g=517&token={k}",
                        new[] {"0", "1", "2", "3", "4", "5", "6", "7"}, apiKey, source.ToString(),
                        persistentCache, tileFetcher,null, appName);
                case KnownTileSource.StamenToner:
                    return new HttpTileSource(new GlobalSphericalMercator(),
                        "http://{s}.tile.stamen.com/toner/{z}/{x}/{y}.png",
                        new[] {"a", "b", "c", "d"}, name: source.ToString(),
                        persistentCache: persistentCache, tileFetcher: tileFetcher,
                        attribution: OpenStreetMapAttribution, appName: appName);
                case KnownTileSource.StamenTonerLite:
                    return new HttpTileSource(new GlobalSphericalMercator(),
                        "http://{s}.tile.stamen.com/toner-lite/{z}/{x}/{y}.png",
                        new[] {"a", "b", "c", "d"}, name: source.ToString(),
                        persistentCache: persistentCache, tileFetcher: tileFetcher,
                        attribution: OpenStreetMapAttribution, appName: appName);
                case KnownTileSource.StamenWatercolor:
                    return new HttpTileSource(new GlobalSphericalMercator(),
                        "http://{s}.tile.stamen.com/watercolor/{z}/{x}/{y}.png",
                        new[] {"a", "b", "c", "d"}, name: source.ToString(),
                        persistentCache: persistentCache, tileFetcher: tileFetcher,
                        attribution: OpenStreetMapAttribution, appName: appName);
                case KnownTileSource.StamenTerrain:
                    return
                        new HttpTileSource(
                            new GlobalSphericalMercator(4)
                            {
                                Extent = new Extent(-14871588.04, 2196494.41775, -5831227.94199995, 10033429.95725)
                            },
                            "http://{s}.tile.stamen.com/terrain/{z}/{x}/{y}.png",
                            new[] {"a", "b", "c", "d"}, name: source.ToString(),
                            persistentCache: persistentCache, tileFetcher: tileFetcher,
                            attribution: OpenStreetMapAttribution, appName: appName);
                case KnownTileSource.EsriWorldTopo:
                    return new HttpTileSource(new GlobalSphericalMercator(),
                        "https://server.arcgisonline.com/ArcGIS/rest/services/World_Topo_Map/MapServer/tile/{z}/{y}/{x}",
                        name: source.ToString(), persistentCache: persistentCache, tileFetcher: tileFetcher, appName: appName);
                case KnownTileSource.EsriWorldPhysical:
                    return new HttpTileSource(new GlobalSphericalMercator(0, 8),
                        "https://server.arcgisonline.com/ArcGIS/rest/services/World_Physical_Map/MapServer/tile/{z}/{y}/{x}",
                        name: source.ToString(), persistentCache: persistentCache, tileFetcher: tileFetcher, appName: appName);
                case KnownTileSource.EsriWorldShadedRelief:
                    return new HttpTileSource(new GlobalSphericalMercator(0, 13),
                        "https://server.arcgisonline.com/ArcGIS/rest/services/World_Shaded_Relief/MapServer/tile/{z}/{y}/{x}",
                        name: source.ToString(), persistentCache: persistentCache, tileFetcher: tileFetcher, appName: appName);
                case KnownTileSource.EsriWorldReferenceOverlay:
                    return new HttpTileSource(new GlobalSphericalMercator(0, 13),
                        "https://server.arcgisonline.com/ArcGIS/rest/services/Reference/World_Reference_Overlay/MapServer/tile/{z}/{y}/{x}",
                        name: source.ToString(), persistentCache: persistentCache, tileFetcher: tileFetcher, appName: appName);
                case KnownTileSource.EsriWorldTransportation:
                    return new HttpTileSource(new GlobalSphericalMercator(),
                        "https://server.arcgisonline.com/ArcGIS/rest/services/Reference/World_Transportation/MapServer/tile/{z}/{y}/{x}",
                        name: source.ToString(), persistentCache: persistentCache, tileFetcher: tileFetcher, appName: appName);
                case KnownTileSource.EsriWorldBoundariesAndPlaces:
                    return new HttpTileSource(new GlobalSphericalMercator(),
                        "https://server.arcgisonline.com/ArcGIS/rest/services/Reference/World_Boundaries_and_Places/MapServer/tile/{z}/{y}/{x}",
                        name: source.ToString(), persistentCache: persistentCache, tileFetcher: tileFetcher, appName: appName);
                case KnownTileSource.EsriWorldDarkGrayBase:
                    return new HttpTileSource(new GlobalSphericalMercator(0, 16),
                        "https://server.arcgisonline.com/arcgis/rest/services/Canvas/World_Dark_Gray_Base/MapServer/tile/{z}/{y}/{x}",
                        name: source.ToString(), persistentCache: persistentCache, tileFetcher: tileFetcher, appName: appName);
                default:
                    throw new NotSupportedException("KnownTileSource not known");
            }
        }

        private static byte[] FetchGoogleTile(Uri arg)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Referer", "http://maps.google.com/");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", @"Mozilla / 5.0(Windows; U; Windows NT 6.0; en - US; rv: 1.9.1.7) Gecko / 20091221 Firefox / 3.5.7");

            return httpClient.GetByteArrayAsync(arg).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}