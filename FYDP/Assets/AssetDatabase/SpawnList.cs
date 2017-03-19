using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnList : MonoBehaviour {

    public List<GameObject> chairs;
    public List<GameObject> tables;
    public List<GameObject> sofas;
    public List<GameObject> storage;
    public List<GameObject> drawers;
    public List<GameObject> lights;
    public List<GameObject> beds;

    public List<Sprite> chairSprites;
    public List<Sprite> tableSprites;
    public List<Sprite> sofaSprites;
    public List<Sprite> storageSprites;
    public List<Sprite> drawerSprites;
    public List<Sprite> lightSpritess;
    public List<Sprite> bedSprites;

    private static string CHAIR_ASSETS = "chairassets";
    private static string DRAWER_ASSETS = "drawerassets";
    private static string TABLE_ASSETS = "tableassets";
    private static string SOFA_ASSETS = "sofaassets";
    private static string BED_ASSETS = "bedassets";
    private static string STORGE_ASSETS = "storageassets";
    private static string LIGHT_ASSETS = "lightassets";


    public GameObject findAsset(string bundle, string asset)
    {
        List<GameObject> bundleList = findBundle(bundle);
        foreach (GameObject gObject in bundleList)
        {
            if (gObject.name.Equals(asset))
            {
                return gObject;
            }
        }
        Debug.Log("Asset: " + asset + " from bundle: " + bundle + " not found!");
        return null;
    }

    public List<Sprite> findBundleIcon(string bundle)
    {
        if (bundle.Equals(CHAIR_ASSETS))
            return chairSprites;
        else if (bundle.Equals(DRAWER_ASSETS))
            return drawerSprites;
        else if (bundle.Equals(TABLE_ASSETS))
            return tableSprites;
        else if (bundle.Equals(SOFA_ASSETS))
            return sofaSprites;
        else if (bundle.Equals(BED_ASSETS))
            return bedSprites;
        else if (bundle.Equals(STORAGE_DICTIONARY))
            return storageSprites;
        else if (bundle.Equals(LIGHT_ASSETS))
            return lightSpritess;
        else
            return new List<Sprite>();
    }

    public Sprite findAssetIcon(string bundle, int index)
    {
        return findBundleIcon(bundle)[index];
    }

    public List<GameObject> findBundle(string bundle)
    {
        if (bundle.Equals(CHAIR_ASSETS))
            return chairs;
        else if (bundle.Equals(DRAWER_ASSETS))
            return drawers;
        else if (bundle.Equals(TABLE_ASSETS))
            return tables;
        else if (bundle.Equals(SOFA_ASSETS))
            return sofas;
        else if (bundle.Equals(BED_ASSETS))
            return beds;
        else if (bundle.Equals(STORAGE_DICTIONARY))
            return storage;
        else if (bundle.Equals(LIGHT_ASSETS))
            return lights;
        else
            return new List<GameObject>();
    }

    public FurnitureProperty findAssetProperties(string bundle, string asset)
    {
        return FURNITURE_DICTIONARY[bundle][asset];
    }

    public static Dictionary<string, FurnitureProperty> CHAIR_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "IkeaForsbySmallStool", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaForsbySmallStool", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaFritzChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaFritzChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaGilbertChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaGilbertChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaJulesSwivelChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaJulesSwivelChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaKlappeChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaKlappeChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaSkruvstaSwivelChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaSkruvstaSwivelChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IngolfChairWithArmrest", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IngolfChairWithArmrest", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } }
    };

    public static Dictionary<string, FurnitureProperty> TABLE_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "Ike010002BjurstaTableAndRogerChairs", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "Ike010002BjurstaTableAndRogerChairs", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaFornbroPedestalTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaFornbroPedestalTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaGrimleTableAnd5Chairs", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaGrimleTableAnd5Chairs", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaGustavDesk", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaGustavDesk", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaHemnesCoffeeTableBrown", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaHemnesCoffeeTableBrown", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaLackBlackTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaLackBlackTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaVikaManneTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaVikaManneTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
    };

    public static Dictionary<string, FurnitureProperty> DRAWER_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "AnesChestOf2DrawersBrichVeneer", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "AnesChestOf2DrawersBrichVeneer", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaAlexDrawerWhite", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaAlexDrawerWhite", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaBestaStorageCombinationWithDoorsDrawers", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaBestaStorageCombinationWithDoorsDrawers", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaHemnesChestOf3Drawers", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaHemnesChestOf3Drawers", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
    };

    public static Dictionary<string, FurnitureProperty> SOFA_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "IkeaArild2SeatSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaArild2SeatSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaExarby3SeatsSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaExarby3SeatsSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaKipplan2SeatSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaKipplan2SeatSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaSolsta2SeatsSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaSolsta2SeatsSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaTullstaArmchair", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaTullstaArmchair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaTylosandCornerSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaTylosandCornerSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaVreta3SeatSofaMjukIvory", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaVreta3SeatSofaMjukIvory", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } }
    };

    public static Dictionary<string, FurnitureProperty> BED_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "IkeaBeddingeSofaBedFrame", new FurnitureProperty { bundle = BED_ASSETS, assetName = "IkeaBeddingeSofaBedFrame", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaHeimdalBed160X200", new FurnitureProperty { bundle = BED_ASSETS, assetName = "IkeaHeimdalBed160X200", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaSorumQueenBedFrame", new FurnitureProperty { bundle = BED_ASSETS, assetName = "IkeaSorumQueenBedFrame", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } }
    };

    public static Dictionary<string, FurnitureProperty> STORAGE_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "IkeaBillyBookcase", new FurnitureProperty { bundle = STORGE_ASSETS, assetName = "IkeaBillyBookcase", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaLaxvikShelving", new FurnitureProperty { bundle = STORGE_ASSETS, assetName = "IkeaLaxvikShelving", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } }
    };

    public static Dictionary<string, FurnitureProperty> LIGHT_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "IkeaAntifoniWorkLamp", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaAntifoniWorkLamp", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaBasiskPendantLamp", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaBasiskPendantLamp", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaBasiskTableLamp", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaBasiskTableLamp", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "IkeaDipodiFloorLamp", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaDipodiFloorLamp", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } }
    };

    public static Dictionary<string, Dictionary<string, FurnitureProperty>> FURNITURE_DICTIONARY = new Dictionary<string, Dictionary<string, FurnitureProperty>>()
    {
        { CHAIR_ASSETS, CHAIR_DICTIONARY },
        { TABLE_ASSETS, TABLE_DICTIONARY },
        { DRAWER_ASSETS, DRAWER_DICTIONARY },
        { SOFA_ASSETS, SOFA_DICTIONARY },
        { BED_ASSETS, BED_DICTIONARY },
        { STORGE_ASSETS, STORAGE_DICTIONARY },
        { LIGHT_ASSETS, LIGHT_DICTIONARY}
    };

}
