-- phpMyAdmin SQL Dump
-- version 4.0.10.14
-- http://www.phpmyadmin.net
--
-- Host: localhost:3306
-- Generation Time: Mar 25, 2017 at 02:16 AM
-- Server version: 5.6.31
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `monisk_fydp`
--

-- --------------------------------------------------------

--
-- Table structure for table `catalog_table`
--

CREATE TABLE IF NOT EXISTS `catalog_table` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CATEGORY` varchar(100) NOT NULL DEFAULT '""',
  `NAME` varchar(500) NOT NULL DEFAULT '""',
  `TYPE` varchar(500) NOT NULL DEFAULT '""',
  `DESCRIPTION` text NOT NULL,
  `DIMENSIONS` varchar(500) NOT NULL DEFAULT '""',
  `IMAGE` text NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=85 ;

--
-- Dumping data for table `catalog_table`
--

INSERT INTO `catalog_table` (`ID`, `CATEGORY`, `NAME`, `TYPE`, `DESCRIPTION`, `DIMENSIONS`, `IMAGE`) VALUES
(5, '"Chair"', '"Klappe Chair"', '"GROUND_PLACEABLE"', 'A deep-red swivel home-office chair with comfy seat and adjustable height.', '"1.14m x 0.80m x 0.80m"', 'https://www.polantis.com/ikea/klappe-chair'),
(4, '"Chair"', '"Jules Swivel Chair"', '"GROUND_PLACEABLE"', 'A light grey, comfortable, plastic and metal chair with adjustable height.', '"0.53m x 0.56m x 0.56m"', 'https://www.polantis.com/ikea/jules-swivel-chair'),
(3, '"Chair"', '"Gilbert Chair"', '"GROUND_PLACEABLE"', 'An elegant white, stackable chair.', '"0.85m x 0.47m x 0.47m"', 'https://www.polantis.com/ikea/gilbert-chair'),
(2, '"Chair"', '"Fritz Chair"', '"GROUND_PLACEABLE"', 'A light brown, sturdy chair perfect around the dining table.', '"0.86m x 0.66m x 0.58m"', 'https://www.polantis.com/ikea/fritz-chair'),
(1, '"Chair"', '"Forsby Small Stool"', '"GROUND_PLACEABLE"', 'A light green stool perfect for the dining room.', '"0.45m x 0.35m x 0.40m"', 'https://www.polantis.com/ikea/forsby-small-stool'),
(6, '"Chair"', '"Skruvasta Swivel Chair"', '"GROUND_PLACEABLE"', 'A contemporary, dark-red swivel office chair.', '"0.90m x 0.44m x 0.44m"', 'https://www.polantis.com/ikea/skruvsta-swivel-chair'),
(7, '"Chair"', '"Ingolf Chair With Armrest"', '"GROUND_PLACEABLE"', 'A beige dining chair with arm support ideal for the dining room.', '"0.91m x 0.47m x 0.58m"', 'https://www.polantis.com/ikea/ingolf-chair-with-armrest'),
(8, '"Chair"', '"Herman Chair"', '"GROUND_PLACEABLE"', 'A casual olive green chair with sturdy metal legs.', '""', 'https://www.polantis.com/ikea/ikea-herman-chair'),
(9, '"Chair"', '"Snille Swivel Chair"', '"GROUND_PLACEABLE"', 'A sky blue swivel office chair with plastic seat and back.', '"0.97m x 0.56m x 0.55m"', 'https://www.polantis.com/ikea/snille-swivel-chair'),
(10, '"Chair"', '"Vibbyn Armchair"', '"GROUND_PLACEABLE"', 'Authentic straw chair with wicker weave.', '"0.74m x 0.69m x 0.71m"', 'https://www.polantis.com/ikea/vibbyn-armchair'),
(11, '"Chair"', '"Allak Swivel Chair"', '"GROUND_PLACEABLE"', 'A light blue swivel office chair with lumbar support.', '"0.75m x 0.45m x 0.45m"', 'https://www.polantis.com/ikea/allak-swivel-chair'),
(12, '"Chair"', '"Emmabo Rocking Chair"', '"GROUND_PLACEABLE"', 'A modern style, dark blue rocking chair ideal for relaxing.', '"0.72m x 0.60m x 0.99m"', 'https://www.polantis.com/ikea/emmabo-rocking-chair'),
(13, '"Chair"', '"Grankulla Futon Armchair"', '"GROUND_PLACEABLE"', 'A Japanese style wooden chair with white seat.', '"0.80m x 0.70m x 1.10m"', 'https://www.polantis.com/ikea/grankulla-futon-armchair'),
(14, '"Chair"', '"Gullholmen Rocking Chair"', '"GROUND_PLACEABLE"', 'A contemporary rocking chair with wicker design.', '"0.75m x 0.61m x 0.69m"', 'https://www.polantis.com/ikea/gullholmen-rocking-chair'),
(15, '"Chair"', '"Karlskrona Lounger Chair"', '"GROUND_PLACEABLE"', 'A full-body, comfortable, wicker lounger chair. ,', '"1.00m x 1.82m x 0.74m"', 'https://www.polantis.com/ikea/karlskrona-lounger-chair'),
(16, '"Chair"', '"Poang Armchair"', '"GROUND_PLACEABLE"', 'A comfortable sofa-esque chair with black faux leather.', '"1.0m x 0.68m x 0.83m"', 'https://www.polantis.com/ikea/poang-armchair'),
(17, '"Chair"', '"Sevnning Desk Chair"', '"GROUND_PLACEABLE"', 'A small, dark-grey office chair.', '"0.90m x 0.47m x 0.48m"', 'https://www.polantis.com/ikea/sevnning-desk-chair'),
(18, '"Chair"', '"Mirima High Stool"', '"GROUND_PLACEABLE"', 'Dark grey, metal stool with foot rest.', '"0.80m x 0.35m x 0.40m"', 'https://www.polantis.com/mirima/tabouret-haut-nubo'),
(19, '"Chair"', '"Mirima Pub Stool"', '"GROUND_PLACEABLE"', 'A high-stool with black seat and light-grey back support.', '""', 'https://www.polantis.com/mirima/tabouret-pub-dossier-plexi'),
(20, '"Chair"', '"Mirima Roma Stool"', '"GROUND_PLACEABLE"', 'An ocher seated bar stool with adjustable height.', '""', 'https://www.polantis.com/mirima/tabouret-roma'),
(21, '"Chair"', '"Mirima Tractor Stool"', '"GROUND_PLACEABLE"', 'An all black, metal, perforated stool with back support.', '""', 'https://www.polantis.com/mirima/tabouret-tracteur'),
(22, '"Chair"', '"Brushed Steel Chair"', '"GROUND_PLACEABLE"', 'A french designed, elegant, stainles steel chair.', '"0.84m x 0.42m x 0.46m"', 'https://www.polantis.com/souvignetdesign/chaise-ds-no-1-acier-brosse'),
(23, '"Table"', '"Jursta Table Set"', '"GROUND_PLACEABLE"', 'A complete light brown, wooden dining table set with 6 chairs.', '"0.74m x 1.75m x 0.95m"', 'https://www.polantis.com/ikea/bjursta-table-and-roger-chairs'),
(24, '"Table"', '"Fornbro Pedestal Table"', '"GROUND_PLACEABLE"', 'Small side table with converging, curved design.', '"0.51m x 0.55m x 0.55m"', 'https://www.polantis.com/ikea/fornbro-pedestal-table'),
(25, '"Table"', '"Grimle Table Set"', '"GROUND_PLACEABLE"', 'A white, wooden table with 5 matching chairs.', '"0.74m x 1.0m x 1.8m"', 'https://www.polantis.com/ikea/grimle-table-and-5-chairs'),
(26, '"Table"', '"Gustav Desk"', '"GROUND_PLACEABLE"', 'A dark brown, wooden computer desk.', '"0.85m x 1.1m x 0.60m"', 'https://www.polantis.com/ikea/gustav-desk'),
(27, '"Table"', '"Hemnes Coffee Table"', '"GROUND_PLACEABLE"', 'A dark, short coffee table with storage below.', '""', 'https://www.polantis.com/ikea/hemnes-coffee-table-brown'),
(28, '"Table"', '"Lack Black Table"', '"GROUND_PLACEABLE"', 'A elongated, wooden side table with black finish.', '"0.40m x 1.1m x 0.45m"', 'https://www.polantis.com/ikea/lack-black-table'),
(29, '"Table"', '"Vika Manne Table"', '"GROUND_PLACEABLE"', 'A lime green round table with silver, metal legs.', '"0.75m x 1.08m x 1.08m"', 'https://www.polantis.com/ikea/vika-manne-table'),
(30, '"Table"', '"Bankas Coffee Table"', '"GROUND_PLACEABLE"', 'A contemporary black coffee table with elegant design.', '"0.35m x 1.5m x 0.50m"', 'https://www.polantis.com/ikea/bankas-coffe-table'),
(31, '"Table"', '"Dalfors Coffee Table"', '"GROUND_PLACEABLE"', 'A modern glass coffee table top with metal support.', '"0.41m x 1.08m x 0.60m"', 'https://www.polantis.com/ikea/dalfors-coffee-table'),
(32, '"Table"', '"Granas Coffee Table Pair"', '"GROUND_PLACEABLE"', 'A pair of large and small, glass coffee tables with metal mesh undercarriage.', '""', 'https://www.polantis.com/ikea/granas-coffee-table'),
(33, '"Table"', '"Isala Coffee Table"', '"GROUND_PLACEABLE"', 'Old fashion coffee table with drawer and metalic brown finish.', '""', 'https://www.polantis.com/ikea/isala-coffee-table'),
(34, '"Table"', '"Klubbo Coffee Table"', '"GROUND_PLACEABLE"', 'A rectangular table with a durable veneered surface, stain resistant and easy to keep clean.', '""', 'https://www.polantis.com/ikea/klubbo-coffee-table'),
(35, '"Table"', '"Lack Side Table"', '"GROUND_PLACEABLE"', 'A beige, shelf side table with swivel wheels.', '""', 'https://www.polantis.com/ikea/lack-side-table-wood'),
(36, '"Table"', '"Strind Side Table"', '"GROUND_PLACEABLE"', 'A transparent, round side table with wheels.', '""', 'https://www.polantis.com/ikea/strind-side-table-round'),
(37, '"Table"', '"Tofteryd Coffee Table"', '"GROUND_PLACEABLE"', 'A modern white coffee table with sotrage below.', '"0.31m x 0.95m x 0.95m"', 'https://www.polantis.com/ikea/tofteryd-coffe-table'),
(38, '"Table"', '"Mirima Table Stand"', '"GROUND_PLACEABLE"', 'A dark grey slender corner table.', '"1.1m x 0.77m x 0.68m"', 'https://www.polantis.com/mirima/table-haute-nubo'),
(39, '"Drawer"', '"Anes 2 Drawers Chest"', '"GROUND_PLACEABLE"', 'A 2 drawer, beige dresser with large storage capacity.', '"0.68m x 1.29m x 0.51m"', 'https://www.polantis.com/ikea/anes-chest-of-2-drawers-brich-veneer'),
(40, '"Drawer"', '"Alex Drawer"', '"GROUND_PLACEABLE"', 'A 6 drawer, white side dresser.', '"0.66m x 0.67m x 0.48m"', 'https://www.polantis.com/ikea/alex-drawer-white'),
(41, '"Drawer"', '"Besta Storage with Doors"', '"GROUND_PLACEABLE"', 'A shutter-less hutch with open and closed storage.', '""', 'https://www.polantis.com/ikea/besta-storage-combination-with-doors-black'),
(42, '"Drawer"', '"Hemnes 3 Drawer Chest"', '"GROUND_PLACEABLE"', 'A light beige 3 drawer dresser.', '"1.1m x 0.97m x 0.51m"', 'https://www.polantis.com/ikea/hemnes-chest-of-3-drawers'),
(43, '"Drawer"', '"Anes Large Drawers Chest"', '"GROUND_PLACEABLE"', 'A beige large drawer chest.', '"0.90m x 1.14m x 0.50m"', 'https://www.polantis.com/ikea/anes-chest-of-4-drawers'),
(44, '"Drawer"', '"Besta Bench"', '"GROUND_PLACEABLE"', 'A white and black bench with large storage capacity.', '""', 'https://www.polantis.com/ikea/besta-bench-with-legs'),
(45, '"Drawer"', '"Besta Storage Combination Black"', '"GROUND_PLACEABLE"', 'A dark grey bench with shelved storage capacity.', '""', 'https://www.polantis.com/ikea/besta-storage-combination-with-doors-black'),
(46, '"Drawer"', '"Besta Storage Unit White"', '"GROUND_PLACEABLE"', 'A white, shelved storage unit with display windows.', '""', 'https://www.polantis.com/ikea/besta-storage-unit-white'),
(47, '"Drawer"', '"Erik Drawer"', '"GROUND_PLACEABLE"', 'A metalic-red two drawer lockable, portable unit.', '"0.51m x 0.47m x 0.39m"', 'https://www.polantis.com/ikea/erik-drawer-lockable'),
(48, '"Drawer"', '"Four Drawer Glass Door Cabinet"', '"GROUND_PLACEABLE"', 'A narrow, white, wooden cabinet hutch.', '""', 'https://www.polantis.com/ikea/glass-door-cabinet-with-four-drawers'),
(49, '"Drawer"', '"Hol Side-table Basket"', '"GROUND_PLACEABLE"', 'A wooden, corner, storage basket with wicker weave.', '""', 'https://www.polantis.com/ikea/hol-side-table-basket'),
(50, '"Drawer"', '"Metod Wall Cabinet"', '"GROUND_PLACEABLE"', 'A narrow, white, shelved cabinet with glass shutters.', '""', 'https://www.polantis.com/ikea/metod-wall-cab-horizontal-with-2-glass-doors-white-jutis-frosted-glass'),
(51, '"Sofa"', '"Arild 2 Seat Sofa"', '"GROUND_PLACEABLE"', 'A black, two-seat, synthetic cotton, sturdy sofa', '"0.81m x 1.56m x 0.94m"', 'https://www.polantis.com/ikea/arild-2-seat-sofa'),
(52, '"Sofa"', '"Exarby 3 Seat Sofa"', '"GROUND_PLACEABLE"', 'A 3-seat extendable, white leather sofa.', '"1.85m x 0.85m x 0.83m"', 'https://www.polantis.com/ikea/exarby-3-seats-sofa'),
(53, '"Sofa"', '"Kipplan 2 Seat Sofa"', '"GROUND_PLACEABLE"', 'A snug, 2-seat red leather sofa.', '"0.67m x 1.80m x 0.88m"', 'https://www.polantis.com/ikea/kipplan-2-seat-sofa'),
(54, '"Sofa"', '"Solsta 2 Seat Sofa"', '"GROUND_PLACEABLE"', 'A dark grey, 2-seat, cotton sofa with wooden frame.', '"0.72m x 1.37m x 0.78m"', 'https://www.polantis.com/ikea/solsta-2-seats-sofa'),
(55, '"Sofa"', '"Tullsta Armchair"', '"GROUND_PLACEABLE"', 'A cotton, white, curved armchair.', '"0.78m x 0.80m x 0.72m"', 'https://www.polantis.com/ikea/tullsta-armchair'),
(56, '"Sofa"', '"Tylosand Corner Sofa"', '"GROUND_PLACEABLE"', 'Large L-shaped, white, corner sofa.', '"0.76m x 2.50m x 0.90m"', 'https://www.polantis.com/ikea/tylosand-corner-sofa'),
(57, '"Sofa"', '"Verta 3 Seat Sofa Mjuk Ivory"', '"GROUND_PLACEABLE"', 'A comfy, 3 seat, ivory, cotton, family Davenport sofa.', '"2.07m x 0.95m x 0.88m"', 'https://www.polantis.com/ikea/vreta-3-seat-sofa-mjuk-ivory'),
(58, '"Sofa"', '"Beddinge Sofa Bed"', '"GROUND_PLACEABLE"', 'A red, cotton, convertible sofa bed for the living room.', '"0.91m x 2.00m x 1.04m"', 'https://www.polantis.com/ikea/beddinge-sofa-bed'),
(59, '"Sofa"', '"Ektorp Armchair"', '"GROUND_PLACEABLE"', 'A 1-seat, ivory, cotton armchair.', '"0.80m x 0.80m x 0.80m"', 'https://www.polantis.com/ikea/ektorp-armchair-vallsta'),
(60, '"Sofa"', '"Fothult 2 Seat Sofa"', '"GROUND_PLACEABLE"', 'A comfy, 2-seat, cotton, ivory coloured sofa.', '"1.46m x 0.88m x 0.88m"', 'https://www.polantis.com/ikea/fothult-2-seat-sofa'),
(61, '"Sofa"', '"Passion Sofa"', '"GROUND_PLACEABLE"', 'A modern, cubic, white sofa with removable cusions.', '"0.59m x 2.62m x 1.00m"', 'https://www.polantis.com/polantis/passion'),
(62, '"Sofa"', '"Modern Divan"', '"GROUND_PLACEABLE"', 'A white, cotton, minimalist style divan.', '"0.68m x 1.82m x 1.18m"', 'https://www.polantis.com/polantis/zero'),
(63, '"Bed"', '"Beddinge Sofa and Bed Frame"', '"GROUND_PLACEABLE"', 'A full-sized sofa bed frame ideal for the living room.', '"0.91m x 2.00m x 1.04m"', 'https://www.polantis.com/ikea/beddinge-sofa-bed-frame'),
(64, '"Bed"', '"Heimdal Bed"', '"GROUND_PLACEABLE"', 'A grey, horizontally barred bed frame.', '"1.20m x 1.60m x 2.00m"', 'https://www.polantis.com/ikea/heimdal-bed-160x200'),
(65, '"Bed"', '"Sorum Queen Bed Frame"', '"GROUND_PLACEABLE"', 'A grey, double bed, bed frame with raised foot rest', '"0.90m x 1.60m x 2.00m"', 'https://www.polantis.com/ikea'),
(66, '"Bed"', '"Beddinge Sofa Bed Frame"', '"GROUND_PLACEABLE"', 'A convertible, sofa bed frame.', '""', 'https://www.polantis.com/ikea/beddinge-sofa-bed-frame'),
(67, '"Storage"', '"Billy Bookcase"', '"GROUND_PLACEABLE"', 'A white, wooden, tall shelf with adjustable shelves.', '""', 'https://www.polantis.com/ikea/billy-bookcase'),
(68, '"Storage"', '"Laxvik Shelving"', '"GROUND_PLACEABLE"', 'A metal shelving unit with 3 levels of storage and cross-bar design.', '"1.27m x 0.80m x 0.40m"', 'https://www.polantis.com/ikea/laxvik-shelving'),
(69, '"Storage"', '"Songa Storage"', '"GROUND_PLACEABLE"', 'A metal, barred shelving rack for the bathroom.', '"0.80m x 0.35m x 0.35m"', 'https://www.polantis.com/ikea/songa-storage'),
(70, '"Storage"', '"Songa Wall Shelf"', '"WALL_PLACEABLE"', 'A metal shelf ideal for the bathroom.', '"0.60m x 0.60m x 0.13m"', 'https://www.polantis.com/ikea/songa-wall-shelf'),
(71, '"Light"', '"Antifoni Work Lamp"', '"GROUND_PLACEABLE"', 'A metalic lamp with adjustable arm and head.', '"0.50m x 0.22m x 0.22m"', 'https://www.polantis.com/ikea/antifoni-work-lamp'),
(72, '"Light"', '"Basisk Pendant Lamp"', '"CEILING_PLACEABLE"', 'A metalic lamp cover to hang from the ceiling.', '"1.50m x 0.20m x 0.20m"', 'https://www.polantis.com/ikea/basisk-pendant-lamp'),
(73, '"Light"', '"Basisk Table Lamp"', '"GROUND_PLACEABLE"', 'A table top lamp with a classic cone lamp shade', '"0.40m x 0.15m x 0.15m"', 'https://www.polantis.com/ikea/basisk-table-lamp'),
(74, '"Light"', '"Dipodi Floor Lamp"', '"GROUND_PLACEABLE"', 'A dual-function lamp with a cast iron stand and diffusing glass shades along with an adjustable dimmer.', '"1.80m x 0.38m x 0.38m"', 'https://www.polantis.com/ikea/dipodi-floor-lamp'),
(75, '"Light"', '"Kroby Floor Lamp"', '"GROUND_PLACEABLE"', 'Downwards facing, standard, modern, corner lamp.', '""', 'https://www.polantis.com/ikea/kroby-lampadaire'),
(76, '"Light"', '"Kroby Floor Lamp"', '"GROUND_PLACEABLE"', 'Upwards facing, standard, modern, corner lamp.', '""', 'https://www.polantis.com/ikea/kroby-lampadaire-variante-2'),
(77, '"Light"', '"Kvart Floor Lamp"', '"GROUND_PLACEABLE"', 'Single street post corner lamp.', '""', 'https://www.polantis.com/ikea/kvart-lampadaire'),
(78, '"Light"', '"Kvart Floor Lamp"', '"GROUND_PLACEABLE"', 'Three-headed, dark grey, street post lamp.', '""', 'https://www.polantis.com/ikea/kvart-lampadaire-avec-3-spots'),
(79, '"Light"', '"Minut Floor Lamp"', '"GROUND_PLACEABLE"', 'Three-headed metalic lamp with glass bulb shades.', '""', 'https://www.polantis.com/ikea/minut-lampadaire'),
(80, '"Light"', '"Minimalist Floor Lamp"', '"GROUND_PLACEABLE"', 'Simple corner lamp with white, conular lamp shade.', '""', 'https://www.polantis.com/ikea/not-lampadaire'),
(81, '"Light"', '"Minimalist Floor Lamp Variation"', '"GROUND_PLACEABLE"', 'Simple corner lamp with white, conular lamp shade, and secondary head.', '""', 'https://www.polantis.com/ikea/not-lampadaire-variante-2'),
(82, '"Light"', '"Basisk Wall Lighting Track"', '"WALL_PLACEABLE"', 'A metal lighting track that is secured to a wall.', '"0.25m x 0.07m x 0.07m"', 'https://www.polantis.com/ikea/basisk-lighting-track'),
(83, '"Light"', '"Ceiling Fado Suspension Lamp"', '"CEILING_PLACEABLE"', 'A translucent ball suspension lamp.', '"1.30m x 0.30m x 0.30m"', 'https://www.polantis.com/ikea/fado-suspension'),
(84, '"Light"', '"Flygge Wall Spotlight"', '"WALL_PLACEABLE"', 'A metalic spotlight lamp to hang on walls.', '"0.35m x 0.16m x 0.26m"', 'https://www.polantis.com/ikea/flygge-wall-spotlight');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
