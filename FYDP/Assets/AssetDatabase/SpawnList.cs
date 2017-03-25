using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnList : MonoBehaviour
{

    public List<GameObject> chairs;
    public List<GameObject> tables;
    public List<GameObject> sofas;
    public List<GameObject> storage;
    public List<GameObject> drawers;
    public List<GameObject> lights;
    public List<GameObject> beds;
    public List<GameObject> others;

    public List<Sprite> chairSprites;
    public List<Sprite> tableSprites;
    public List<Sprite> sofaSprites;
    public List<Sprite> storageSprites;
    public List<Sprite> drawerSprites;
    public List<Sprite> lightSpritess;
    public List<Sprite> bedSprites;
    public List<Sprite> otherSprites;

    private static string CHAIR_ASSETS = "chairassets";
    private static string DRAWER_ASSETS = "drawerassets";
    private static string TABLE_ASSETS = "tableassets";
    private static string SOFA_ASSETS = "sofaassets";
    private static string BED_ASSETS = "bedassets";
    private static string STORGE_ASSETS = "storageassets";
    private static string LIGHT_ASSETS = "lightassets";
    private static string OTHER_ASSETS = "otherassets";

    private static string CHAIR_CATEGORY_TITLE = "Chairs";
    private static string DRAWER_CATEGORY_TITLE = "Drawers";
    private static string TABLE_CATEGORY_TITLE = "Tables";
    private static string SOFA_CATEGORY_TITLE = "Sofas";
    private static string BED_CATEGORY_TITLE = "Beds";
    private static string STORAGE_CATEGORY_TITLE = "Storage";
    private static string LIGHT_CATEGORY_TITLE = "Lights";
    private static string OTHER_CATEGORY_TITLE = "Others";


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
        else if (bundle.Equals(OTHER_ASSETS))
            return otherSprites;
        else
            return new List<Sprite>();
    }


    public string getCategoryTitle(string bundle)
    {
        if (bundle.Equals(CHAIR_ASSETS))
            return CHAIR_CATEGORY_TITLE;
        else if (bundle.Equals(DRAWER_ASSETS))
            return DRAWER_CATEGORY_TITLE;
        else if (bundle.Equals(TABLE_ASSETS))
            return TABLE_CATEGORY_TITLE;
        else if (bundle.Equals(SOFA_ASSETS))
            return SOFA_CATEGORY_TITLE;
        else if (bundle.Equals(BED_ASSETS))
            return BED_CATEGORY_TITLE;
        else if (bundle.Equals(STORAGE_DICTIONARY))
            return STORAGE_CATEGORY_TITLE;
        else if (bundle.Equals(LIGHT_ASSETS))
            return LIGHT_CATEGORY_TITLE;
        else if (bundle.Equals(OTHER_ASSETS))
            return OTHER_CATEGORY_TITLE;
        return "";
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
        else if (bundle.Equals(OTHER_ASSETS))
            return others;
        else
            return new List<GameObject>();
    }

    public FurnitureProperty findAssetProperties(string bundle, string asset)
    {
        return FURNITURE_DICTIONARY[bundle][asset];
    }

    public static Dictionary<string, FurnitureProperty> CHAIR_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "IkeaForsbySmallStool", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaForsbySmallStool", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Forsby Small Stool", description = "A light green stool perfect for the dining room.\nDimensions: 0.45 x 0.35 x 0.40m" } },
        {  "IkeaFritzChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaFritzChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Fritz Chair", description = "A light brown, sturdy chair perfect around the dining table.\nDimensions: 0.86 x 0.66 x 0.58m" } },
        {  "IkeaGilbertChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaGilbertChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Gilbert Chair", description = "An elegant white, stackable chair.\nDimensions: 0.85 x 0.47 x 0.47m" } },
        {  "IkeaJulesSwivelChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaJulesSwivelChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Jules Swivel Chair", description = "A light grey, comfortable, plastic and metal chair with adjustable height.\nDimensions: 0.53 x 0.56 x 0.56m" } },
        {  "IkeaKlappeChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaKlappeChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Klappe Chair", description = "A deep-red swivel home-office chair with comfy seat and adjustable height.\nDimensions: 1.14 x 0.80 x 0.80m" } },
        {  "IkeaSkruvstaSwivelChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaSkruvstaSwivelChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Skruvasta Swivel Chair", description = "A contemporary, dark-red swivel office chair.\nDimensions: 0.90 x 0.44 x 0.44m" } },
        {  "IngolfChairWithArmrest", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IngolfChairWithArmrest", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Ingolf Chair With Armrest", description = "A beige dining chair with arm support ideal for the dining room.\nDimensions: 0.91 x 0.47 x 0.58m" } },
        {  "IkeaHermanChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaHermanChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Herman Chair", description = "A casual olive green chair with sturdy metal legs." } },
        {  "IkeaSnilleSwivelChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaSnilleSwivelChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Snille Swivel Chair", description = "A sky blue swivel office chair with plastic seat and back.\nDimensions: 0.97 x 0.56 x 0.55m" } },
        {  "IkeaVibbynArmchair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaVibbynArmchair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Vibbyn Armchair", description = "Authentic strw chair with wicker weave.\nDimensions: 0.74 x 0.69 x 0.71m" } },
        {  "IkeaAllakSwivelChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaAllakSwivelChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Allak Swivel Chair", description = "A light blue swivel office chair with lumbar support.\nDimensions: 0.75 x 0.45 x 0.45m" } },
        {  "IkeaEmmaboRockingChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaEmmaboRockingChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Emmabo Rocking Chair", description = "A modern style, dark blue rocking chair ideal for relaxing.\nDimensions: 0.72 x 0.60 x 0.99m" } },
        {  "IkeaGrankullaFutonArmchair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaGrankullaFutonArmchair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Grankulla Futon Armchair", description = "A Japanese style wooden chair with white seat.\nDimensions: 0.80 x 0.70 x 1.10m" } },
        {  "IkeaGullholmenRockingChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaGullholmenRockingChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Gullholmen Rocking Chair", description = "A contemporary rocking chair with wicker design.\nDimensions: 0.75 x 0.61 x 0.69m" } },
        {  "IkeaKarlskronaLoungerChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaKarlskronaLoungerChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE , title = "Karlskrona Lounger Chair", description = "A full-body, comfortable, wicker lounger chair.\nDimensions: 1.00 x 1.82 x 0.74m"} },
        {  "IkeaPoangArmchair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaPoangArmchair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Poang Armchair", description = "A comfortable sofa-esque chair with black faux leather.\nDimensions: 1.0 x 0.68 x 0.83m" } },
        {  "IkeaSevnningDeskChair", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "IkeaSevnningDeskChair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Sevnning Desk Chair", description = "A small, dark-grey office chair.\nDimensions: 0.90 x 0.47 x 0.48m" } },
        {  "MirimaTabouretHautNubo", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "MirimaTabouretHautNubo", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Mirima High Stool", description = "Dark grey, metal stool with foot rest.\nDimensions: 0.80 x 0.35 x 0.40m" } },
        {  "MirimaTabouretPubDossierPlexi", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "MirimaTabouretPubDossierPlexi", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Mirima Pub Stool", description = "A high-stool with black seat and light-grey back support." } },
        {  "MirimaTabouretRoma", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "MirimaTabouretRoma", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Mirima Roma Stool", description = "An ocher seated bar stool with adjustable height." } },
        {  "MirimaTabouretTracteur", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "MirimaTabouretTracteur", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Mirima Tractor Stool", description = "An all black, metal, perforated stool with back support." } },
        {  "SouvignetdesignChaiseDsNo1AcierBrosse", new FurnitureProperty { bundle = CHAIR_ASSETS, assetName = "SouvignetdesignChaiseDsNo1AcierBrosse", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Brushed Steel Chair", description = "A french designed, elegant, stainles steel chair.\nDimensions: 0.84 x 0.42 x 0.46m" } }
    };

    public static Dictionary<string, FurnitureProperty> TABLE_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "Ike010002BjurstaTableAndRogerChairs", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "Ike010002BjurstaTableAndRogerChairs", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Jursta Table Set", description="A complete light brown, wooden dining table set with 6 chairs.\nDimensions: 0.74 x 1.75 x 0.95m" } },
        {  "IkeaFornbroPedestalTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaFornbroPedestalTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Fornbro Pedestal Table", description="Small side table with converging, curved design.\nDimensions: 0.51 x 0.55 x 0.55m" } },
        {  "IkeaGrimleTableAnd5Chairs", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaGrimleTableAnd5Chairs", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Grimle Table Set", description="A white, wooden table with 5 matching chairs.\nDimensions: 0.74 x 1.0 x 1.8m" } },
        {  "IkeaGustavDesk", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaGustavDesk", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Gustav Desk", description="A dark brown, wooden computer desk.\nDimensions: 0.85 x 1.1 x 0.60m" } },
        {  "IkeaHemnesCoffeeTableBrown", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaHemnesCoffeeTableBrown", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Hemnes Coffee Table", description="A dark, short coffee table with storage below." } },
        {  "IkeaLackBlackTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaLackBlackTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Lack Black Table", description="A elongated, wooden side table with black finish.\nDimensions: 0.40 x 1.1 x 0.45m" } },
        {  "IkeaVikaManneTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaVikaManneTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Vika Manne Table", description="A lime green round table with silver, metal legs.\nDimensions: 0.75 x 1.08 x 1.08m" } },
        {  "IkeaBankasCoffeTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaBankasCoffeTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Bankas Coffee Table", description="A contemporary black coffee table with elegant design.\nDimensions: 0.35 x 1.5 x 0.50m" } },
        {  "IkeaDalforsCoffeeTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaDalforsCoffeeTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Dalfors Coffee Table", description="A modern glass coffee table top with metal support.\nDimensions: 0.41 x 1.08 x 0.60m" } },
        {  "IkeaGranasCoffeeTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaGranasCoffeeTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Granas Coffee Table Pair", description="A pair of large and small, glass coffee tables with metal mesh undercarriage." } },
        {  "IkeaIsalaCoffeeTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaIsalaCoffeeTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Isala Coffee Table", description="Old fashion coffee table with drawer and metalic brown finish." } },
        {  "IkeaKlubboCoffeeTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaKlubboCoffeeTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Klubbo Coffee Table", description="A rectangular table with a durable veneered surface, stain resistant and easy to keep clean." } },
        {  "IkeaLackSideTableWood", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaLackSideTableWood", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Lack Side Table", description="A beige, shelf side table with swivel wheels." } },
        {  "IkeaStrindSideTableRound", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaStrindSideTableRound", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Strind Side Table", description="A transparent, round side table with wheels." } },
        {  "IkeaTofterydCoffeTable", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "IkeaTofterydCoffeTable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Tofteryd Coffee Table", description="A modern white coffee table with sotrage below.\nDimensions: 0.31 x 0.95 x 0.95m" } },
        {  "MirimaTableHauteNubo", new FurnitureProperty { bundle = TABLE_ASSETS, assetName = "MirimaTableHauteNubo", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Mirima Table Stand", description="A dark grey slender corner table.\nDimensions: 1.1 x 0.77 x 0.68m" } },
    };

    public static Dictionary<string, FurnitureProperty> DRAWER_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "AnesChestOf2DrawersBrichVeneer", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "AnesChestOf2DrawersBrichVeneer", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Anes 2 Drawers Chest", description="A 2 drawer, beige dresser with large storage capacity.\nDimensions: 0.68 x 1.29 x 0.51m" } },
        {  "IkeaAlexDrawerWhite", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaAlexDrawerWhite", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Alex Drawer", description="A 6 drawer, white side dresser.\nDimensions: 0.66 x 0.67 x 0.48m" } },
        {  "IkeaBestaStorageCombinationWithDoorsDrawers", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaBestaStorageCombinationWithDoorsDrawers", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Besta Storage with Doors", description="A shutter-less hutch with open and closed storage." } },
        {  "IkeaHemnesChestOf3Drawers", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaHemnesChestOf3Drawers", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Hemnes 3 Drawer Chest", description="A light beige 3 drawer dresser.\nDimensions: 1.1 x 0.97 x 0.51m" } },
        {  "IkeaAnesChestOf4Drawers", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaAnesChestOf4Drawers", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Anes Large Drawers Chest", description="A beige large drawer chest.\nDimensions: 0.90 x 1.14 x 0.50m" } },
        {  "IkeaBestaBenchWithLegs", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaBestaBenchWithLegs", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Besta Bench", description="A white and black bench with large storage capacity." } },
        {  "IkeaBestaStorageCombinationWithDoorsBlack", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaBestaStorageCombinationWithDoorsBlack", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Besta Storage Combination Black", description="A dark grey bench with shelved storage capacity." } },
        {  "IkeaBestaStorageUnitWhite", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaBestaStorageUnitWhite", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Besta Storage Unit White", description="A white, shelved storage unit with display windows." } },
        {  "IkeaErikDrawerLockable", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaErikDrawerLockable", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Erik Drawer", description="A metalic-red two drawer lockable, portable unit.\nDimensions: 0.51 x 0.47 x 0.39m" } },
        {  "IkeaGlassDoorCabinetWithFourDrawers", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaGlassDoorCabinetWithFourDrawers", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Four Drawer Glass Door Cabinet", description="A narrow, white, wooden cabinet hutch." } },
        {  "IkeaHolSideTableBasket", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "IkeaHolSideTableBasket", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Hol Side-table Basket", description="A wooden, corner, storage basket with wicker weave." } },
        {  "MetodWallCabHorizontalWith2GlassDoorsWhiteJutisFrosted", new FurnitureProperty { bundle = DRAWER_ASSETS, assetName = "MetodWallCabHorizontalWith2GlassDoorsWhiteJutisFrosted", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Metod Wall Cabinet", description="A narrow, white, shelved cabinet with glass shutters." } },
    };

    public static Dictionary<string, FurnitureProperty> SOFA_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "IkeaArild2SeatSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaArild2SeatSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Arild 2 Seat Sofa", description="A black, two-seat, synthetic cotton, sturdy sofa\nDimensions: 0.81 x 1.56 x 0.94m" } },
        {  "IkeaExarby3SeatsSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaExarby3SeatsSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Exarby 3 Seat Sofa", description="A 3-seat extendable, white leather sofa.\nDimensions: 1.85 x 0.85 x 0.83m" } },
        {  "IkeaKipplan2SeatSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaKipplan2SeatSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Kipplan 2 Seat Sofa", description="A snug, 2-seat red leather sofa.\nDimensions: 0.67 x 1.80 x 0.88m" } },
        {  "IkeaSolsta2SeatsSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaSolsta2SeatsSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Solsta 2 Seat Sofa", description="A dark grey, 2-seat, cotton sofa with wooden frame.\nDimensions: 0.72 x 1.37 x 0.78m" } },
        {  "IkeaTullstaArmchair", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaTullstaArmchair", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Tullsta Armchair", description="A cotton, white, curved armchair.\nDimensions: 0.78 x 0.80 x 0.72m" } },
        {  "IkeaTylosandCornerSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaTylosandCornerSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Tylosand Corner Sofa", description="Large L-shaped, white, corner sofa.\nDimensions: 0.76 x 2.50 x 0.90m" } },
        {  "IkeaVreta3SeatSofaMjukIvory", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaVreta3SeatSofaMjukIvory", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Verta 3 Seat Sofa Mjuk Ivory", description="A comfy, 3 seat, ivory, cotton, family Davenport sofa.\nDimensions: 2.07 x 0.95 x 0.88m" } },
        {  "IkeaBeddingeSofaBed", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaBeddingeSofaBed", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Beddinge Sofa Bed", description="A red, cotton, convertible sofa bed for the living room.\nDimensions: 0.91 x 2.00 x 1.04m" } },
        {  "IkeaEktorpArmchairVallsta", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaEktorpArmchairVallsta", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Ektorp Armchair", description="A 1-seat, ivory, cotton armchair.\nDimensions: 0.80 x 0.80 x 0.80m" } },
        {  "IkeaFothult2SeatSofa", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "IkeaFothult2SeatSofa", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Fothult 2 Seat Sofa", description="A comfy, 2-seat, cotton, ivory coloured sofa.\nDimensions: 1.46 x 0.88 x 0.88m" } },
        {  "PolantisPassion", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "PolantisPassion", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Passion Sofa", description="A modern, cubic, white sofa with removable cusions.\nDimensions: 0.59 x 2.62 x 1.00m" } },
        {  "PolantisZero", new FurnitureProperty { bundle = SOFA_ASSETS, assetName = "PolantisZero", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Modern Divan", description="A white, cotton, minimalist style divan.\nDimensions: 0.68 x 1.82 x 1.18m" } },
    };

    public static Dictionary<string, FurnitureProperty> BED_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "IkeaBeddingeSofaBedFrame", new FurnitureProperty { bundle = BED_ASSETS, assetName = "IkeaBeddingeSofaBedFrame", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Beddinge Sofa and Bed Frame", description="A full-sized sofa bed frame ideal for the living room.\nDimensions: 0.91 x 2.00 x 1.04m" } },
        {  "IkeaHeimdalBed160X200", new FurnitureProperty { bundle = BED_ASSETS, assetName = "IkeaHeimdalBed160X200", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Heimdal Bed", description="A grey, horizontally barred bed frame.\nDimensions: 1.20 x 1.60 x 2.00m" } },
        {  "IkeaSorumQueenBedFrame", new FurnitureProperty { bundle = BED_ASSETS, assetName = "IkeaSorumQueenBedFrame", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Sorum Queen Bed Frame", description="A grey, double bed, bed frame with raised foot rest\nDimensions: 0.90 x 1.60 x 2.00m" } },
        {  "IkeaBeddingeSofaBedFrame2", new FurnitureProperty { bundle = BED_ASSETS, assetName = "IkeaBeddingeSofaBedFrame2", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title="Beddinge Sofa Bed Frame", description="A convertible, sofa bed frame." } }
    };

    public static Dictionary<string, FurnitureProperty> STORAGE_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "IkeaBillyBookcase", new FurnitureProperty { bundle = STORGE_ASSETS, assetName = "IkeaBillyBookcase", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Billy Bookcase", description = "A white, wooden, tall shelf with adjustable shelves." } },
        {  "IkeaLaxvikShelving", new FurnitureProperty { bundle = STORGE_ASSETS, assetName = "IkeaLaxvikShelving", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Laxvik Shelving", description = "A metal shelving unit with 3 levels of storage and cross-bar design.\nDimensions: 1.27 x 0.80 x 0.40m" } },
        {  "IkeaSongaStorage", new FurnitureProperty { bundle = STORGE_ASSETS, assetName = "IkeaSongaStorage", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Songa Storage", description = "A metal, barred shelving rack for the bathroom.\nDimensions: 0.80 x 0.35 x 0.35m" } },
        {  "IkeaSongaWallShelf", new FurnitureProperty { bundle = STORGE_ASSETS, assetName = "IkeaSongaWallShelf", furnitureType = FurnitureProperty.FurnitureType.WALL_PLACEABLE, title = "Songa Wall Shelf", description = "A metal shelf ideal for the bathroom.\nDimensions: 0.60 x 0.60 x 0.13m" } }
    };

    public static Dictionary<string, FurnitureProperty> LIGHT_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "IkeaAntifoniWorkLamp", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaAntifoniWorkLamp", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Antifoni Work Lamp", description = "A metalic lamp with adjustable arm and head.\nDimensions: 0.50 x 0.22 x 0.22m" } },
        {  "IkeaBasiskPendantLamp", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaBasiskPendantLamp", furnitureType = FurnitureProperty.FurnitureType.CEILING_PLACEABLE, title = "Basisk Pendant Lamp", description = "A metalic lamp cover to hang from the ceiling.\nDimensions: 1.50 x 0.20 x 0.20m" } },
        {  "IkeaBasiskTableLamp", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaBasiskTableLamp", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Basisk Table Lamp", description = "A table top lamp with a classic cone lamp shade\nDimensions: 0.40 x 0.15 x 0.15m" } },
        {  "IkeaDipodiFloorLamp", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaDipodiFloorLamp", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Dipodi Floor Lamp", description = "A dual-function lamp with a cast iron stand and diffusing glass shades along with an adjustable dimmer.\nDimensions: 1.80 x 0.38 x 0.38m" } },
        {  "IkeaKrobyLampadaire", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaKrobyLampadaire", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Kroby Floor Lamp", description = "Downwards facing, standard, modern, corner lamp." } },
        {  "IkeaKrobyLampadaireVariante2", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaKrobyLampadaireVariante2", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Kroby Floor Lamp", description = "Upwards facing, standard, modern, corner lamp." } },
        {  "IkeaKvartLampadaire", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaKvartLampadaire", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Kvart Floor Lamp", description = "Single street post corner lamp." } },
        {  "IkeaKvartLampadaireAvec3Spots", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaKvartLampadaireAvec3Spots", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Kvart Floor Lamp", description = "Three-headed, dark grey, street post lamp." } },
        {  "IkeaMinutLampadaire", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaMinutLampadaire", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Minut Floor Lamp", description = "Three-headed metalic lamp with glass bulb shades." } },
        {  "IkeaNotLampadaire", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaNotLampadaire", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Minimalist Floor Lamp", description = "Simple corner lamp with white, conular lamp shade." } },
        {  "IkeaNotLampadaireVariante2", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaNotLampadaireVariante2", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE, title = "Minimalist Floor Lamp Variation", description = "Simple corner lamp with white, conular lamp shade, and secondary head." } },
        {  "IkeaBasiskLightingTrack", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaBasiskLightingTrack", furnitureType = FurnitureProperty.FurnitureType.WALL_PLACEABLE, title = "Basisk Wall Lighting Track", description = "A metal lighting track that is secured to a wall.\nDimensions: 0.25 x 0.07 x 0.07m" } },
        {  "IkeaFadoSuspension", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaFadoSuspension", furnitureType = FurnitureProperty.FurnitureType.CEILING_PLACEABLE, title = "Ceiling Fado Suspension Lamp", description = "A translucent ball suspension lamp.\nDimensions: 1.30 x 0.30 x 0.30m" } },
        {  "IkeaFlyggeWallSpotlight", new FurnitureProperty { bundle = LIGHT_ASSETS, assetName = "IkeaFlyggeWallSpotlight", furnitureType = FurnitureProperty.FurnitureType.WALL_PLACEABLE, title = "Flygge Wall Spotlight", description = "A metalic spotlight lamp to hang on walls.\nDimensions: 0.35 x 0.16 x 0.26m" } }
    };

    public static Dictionary<string, FurnitureProperty> OTHER_DICTIONARY = new Dictionary<string, FurnitureProperty>()
    {
        {  "sink", new FurnitureProperty { bundle = OTHER_ASSETS, assetName = "sink", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "microwave", new FurnitureProperty { bundle = OTHER_ASSETS, assetName = "microwave", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } },
        {  "oven03", new FurnitureProperty { bundle = OTHER_ASSETS, assetName = "oven03", furnitureType = FurnitureProperty.FurnitureType.GROUND_PLACEABLE } }
    };

    public static Dictionary<string, Dictionary<string, FurnitureProperty>> FURNITURE_DICTIONARY = new Dictionary<string, Dictionary<string, FurnitureProperty>>()
    {
        { CHAIR_ASSETS, CHAIR_DICTIONARY },
        { TABLE_ASSETS, TABLE_DICTIONARY },
        { DRAWER_ASSETS, DRAWER_DICTIONARY },
        { SOFA_ASSETS, SOFA_DICTIONARY },
        { BED_ASSETS, BED_DICTIONARY },
        { STORGE_ASSETS, STORAGE_DICTIONARY },
        { LIGHT_ASSETS, LIGHT_DICTIONARY},
        { OTHER_ASSETS, OTHER_DICTIONARY},
    };

}
