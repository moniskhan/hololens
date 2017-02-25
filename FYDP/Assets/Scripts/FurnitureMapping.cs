
using System.Collections;
using System.Collections.Generic;

public class FurnitureDetail
{
    public string id { get; private set; }
    public string name { get; private set; }
    public string description { get; private set; }
    public double price { get; private set; }
    public string imagePath { get; private set; }

    public FurnitureDetail(string i, string n, string d, double p, string img)
    {
        id = i;
        name = n;
        description = d;
        price = p;
        imagePath = img;
    }
}

public class FurnitureMapping
{
    public static FurnitureMapping Instance { get; private set; }

    public Dictionary<string,FurnitureDetail> furnitureMappings { get; private set; }
    public List<string> furnitureIds { get; private set; }

    public FurnitureMapping()
    {
        string basicTable = "BasicTable", woodenChair = "WoodenChair", modernSofa = "ModernSofa", woodenChair2 = "WoodenChair2",
        deskLamp = "DeskLamp", roundLamp = "RoundLamp", woodenTable = "WoodenTable", r2d2 = "R2D2", basicWoodTable = "BasicWoodTable",
        wallLight = "light_wall", ceilingLight = "light_ceiling";

        furnitureIds =  new List<string>() { basicTable, woodenChair, modernSofa, woodenChair2, deskLamp, roundLamp, woodenTable, r2d2, basicWoodTable, wallLight, ceilingLight }; ;
        furnitureMappings = new Dictionary<string,FurnitureDetail>();

        furnitureMappings.Add(basicTable,
            new FurnitureDetail(
                basicTable, 
                "Basic Table",
                "This is a description for this basic table",
                99.99,
                "Menu Icons/basic_chair"
            ));

        furnitureMappings.Add(woodenChair,
            new FurnitureDetail(
                woodenChair,
                "Wooden Chair",
                "This is a nice wooden chair, very woody ;)",
                99.99,
                "Menu Icons/wooden_chair"
            ));
        furnitureMappings.Add(modernSofa,
            new FurnitureDetail(
                modernSofa,
                "Modern Sofa",
                "sofa king comfortable",
                99.99,
                "Menu Icons/modern_sofa_icon"
            ));
        furnitureMappings.Add(woodenChair2,
            new FurnitureDetail(
                woodenChair2,
                "Wooden Table Style 2",
                "a weird ass wooden chair",
                99.99,
                "Menu Icons/wooden_chair_2"
            ));
        furnitureMappings.Add(deskLamp,
            new FurnitureDetail(
                deskLamp,
                "Desk Lamp",
                "It's an orange desk lamp",
                99.99,
                "Menu Icons/desk_lamp"
            ));
        furnitureMappings.Add(roundLamp,
            new FurnitureDetail(
                roundLamp,
                "Round Lamp",
                "a round lamp that goes around",
                99.99,
                "Menu Icons/round_lamp"
            ));
        furnitureMappings.Add(woodenTable,
            new FurnitureDetail(
                woodenTable,
                "Wooden Table",
                "This is a description for this wooden table",
                99.99,
                "Menu Icons/wooden_table"
            ));
        furnitureMappings.Add(wallLight,
            new FurnitureDetail(
                wallLight,
                "Wall Light",
                "This is a wall light",
                99.99,
                "Menu Icons/wall_light"
            ));
        furnitureMappings.Add(ceilingLight,
            new FurnitureDetail(
                ceilingLight,
                "Ceiling Light",
                "This is a ceiling light",
                99.99,
                "Menu Icons/light_ceiling"
            ));
    }
}