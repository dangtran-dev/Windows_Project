using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Windows.Storage;

namespace Windows_Project;

public class MockDao : IDao
{
    public List<Manufacturers> GetManufacturers()
    {
        var result = new List<Manufacturers>()
        {
            new Manufacturers()
            {
                ManufacturerName = "Toyota",
                ManufacturerPicture = "Assets/toyota_logo.jpg",
                Cars = new List<Cars>()
                {
                    new Cars()
                    {
                        Model = "Toyota Vios",
                        Manufacturer = "Toyota",
                        Price = "458.000.000 VNĐ",
                        Picture = "Assets/toyota_vios.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Raize",
                        Manufacturer = "Toyota",
                        Price = "498.000.000 VNĐ",
                        Picture = "Assets/toyota_raize.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Yaris Cross",
                        Manufacturer = "Toyota",
                        Price = "650.000.000 VNĐ",
                        Picture = "Assets/toyota_yaris_cross.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Innova Cross",
                        Manufacturer = "Toyota",
                        Price = "810.000.000 VNĐ",
                        Picture = "Assets/toyota_innova_cross.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Innova",
                        Manufacturer = "Toyota",
                        Price = "755.000.000 VNĐ",
                        Picture = "Assets/toyota_innova.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Fortuner",
                        Manufacturer = "Toyota",
                        Price = "1.055.000.000 VNĐ",
                        Picture = "Assets/toyota_fortuner.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Veloz Cross",
                        Manufacturer = "Toyota",
                        Price = "638.000.000 VNĐ",
                        Picture = "Assets/toyota_veloz_cross.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Corolla Cross",
                        Manufacturer = "Toyota",
                        Price = "760.000.000 VNĐ",
                        Picture = "Assets/toyota_corolla_cross.png",
                        Condition = "Xe cu"
                    },
                     new Cars()
                    {
                        Model = "Toyota Corolla Altis",
                        Manufacturer = "Toyota",
                        Price = "725.000.000 VNĐ",
                        Picture = "Assets/toyota_corolla_altis.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Wigo",
                        Manufacturer = "Toyota",
                        Price = "360.000.000 VNĐ",
                        Picture = "Assets/toyota_wigo.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Avanza​ Premio",
                        Manufacturer = "Toyota",
                        Price = "558.000.000 VNĐ",
                        Picture = "Assets/toyota_avanza_premio.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Camry",
                        Manufacturer = "Toyota",
                        Price = "1.105.000.000 VNĐ",
                        Picture = "Assets/toyota_camry.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Hilux",
                        Manufacturer = "Toyota",
                        Price = "668.000.000 VNĐ",
                        Picture = "Assets/toyota_hilux.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Land Cruiser",
                        Manufacturer = "Toyota",
                        Price = "4.286.000.000 VNĐ",
                        Picture = "Assets/toyota_land_cruiser.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Toyota Land Cruiser Prado",
                        Manufacturer = "Toyota",
                        Price = "3.460.000.000 VNĐ",
                        Picture = "Assets/toyota_land_cruiser_prado.png",
                        Condition = "Xe cu"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Wolkswagen",
                ManufacturerPicture = "Assets/wolkswagen_logo.jpg",
                Cars = new List<Cars>()
                {
                    new Cars()
                    {
                        Model = "Volkswagen Teramont",
                        Manufacturer = "Wolkswagen",
                        Price = "2.399.000.000 VNĐ",
                        Picture = "Assets/volkswagen_teramont.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Volkswagen Tiguan",
                        Manufacturer = "Wolkswagen",
                        Price = "1.688.000.000 VNĐ",
                        Picture = "Assets/volkswagen_tiguan.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Volkswagen Passat",
                        Manufacturer = "Wolkswagen",
                        Price = "1.399.000.000 VNĐ",
                        Picture = "Assets/volkswagen_passat.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Volkswagen Polo",
                        Manufacturer = "Wolkswagen",
                        Price = "699.000.000 VNĐ",
                        Picture = "Assets/volkswagen_polo.png",
                        Condition = "Xe cu"
                    },
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Ford",
                ManufacturerPicture = "Assets/ford_logo.jpg",
                Cars = new List<Cars>()
                {
                    new Cars()
                    {
                        Model = "Ford Ranger",
                        Manufacturer = "Ford",
                        Price = "699.000.000 VNĐ",
                        Picture = "Assets/ford_ranger.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Ford Ranger Raptor",
                        Manufacturer = "Ford",
                        Price = "1.299.000.000 VNĐ",
                        Picture = "Assets/ford_ranger_raptor.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Ford Everest",
                        Manufacturer = "Ford",
                        Price = "1.099.000.000 VNĐ",
                        Picture = "Assets/ford_everest.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Ford Territory",
                        Manufacturer = "Ford",
                        Price = "799.000.000 VNĐ",
                        Picture = "Assets/ford_territory.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Ford Explorer",
                        Manufacturer = "Ford",
                        Price = "2.099.000.000 VNĐ",
                        Picture = "Assets/ford_explorer.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Ford Transit",
                        Manufacturer = "Ford",
                        Price = "905.000.000 VNĐ",
                        Picture = "Assets/ford_transit.png",
                        Condition = "Xe cu"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Chevrolet",
                ManufacturerPicture = "Assets/chevrolet_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {

                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Nissan",
                ManufacturerPicture = "Assets/nissan_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "Nissan Kicks e-power",
                        Manufacturer = "Nissan",
                        Price = "789.000.000 VNĐ",
                        Picture = "Assets/nissan_kicks_e_power.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Nissan Almera",
                        Manufacturer = "Nissan",
                        Price = "539.000.000 VNĐ",
                        Picture = "Assets/nissan_almera.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Nissan Navara",
                        Manufacturer = "Nissan",
                        Price = "685.000.000 VNĐ",
                        Picture = "Assets/nissan_navara.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Nissan Terra",
                        Manufacturer = "Nissan",
                        Price = "848.000.000 VNĐ",
                        Picture = "Assets/nissan_terra.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Nissan X-Trail",
                        Manufacturer = "Nissan",
                        Price = "839.000.000 VNĐ",
                        Picture = "Assets/nissan_x_trail.png",
                        Condition = "Xe cu"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Hyundai",
                ManufacturerPicture = "Assets/hyundai_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "Hyundai Venue",
                        Manufacturer = "Hyundai",
                        Price = "499.000.000 VNĐ",
                        Picture = "Assets/hyundai_venue.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai Custin​​",
                        Manufacturer = "Hyundai",
                        Price = "820.000.000 VNĐ",
                        Picture = "Assets/hyundai_custin.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai Palisade",
                        Manufacturer = "Hyundai",
                        Price = "1.469.000.000 VNĐ",
                        Picture = "Assets/hyundai_palisade.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai Accent",
                        Manufacturer = "Hyundai",
                        Price = "439.000.000 VNĐ",
                        Picture = "Assets/hyundai_accent.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai SantaFe",
                        Manufacturer = "Hyundai",
                        Price = "1.069.000.000 VNĐ",
                        Picture = "Assets/hyundai_santafe.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai Creta",
                        Manufacturer = "Hyundai",
                        Price = "599.000.000 VNĐ",
                        Picture = "Assets/hyundai_creta.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai Stargazer",
                        Manufacturer = "Hyundai",
                        Price = "489.000.000 VNĐ",
                        Picture = "Assets/hyundai_stargazer.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai Kona",
                        Manufacturer = "Hyundai",
                        Price = "636.000.000 VNĐ",
                        Picture = "Assets/hyundai_kona.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai Grand i10",
                        Manufacturer = "Hyundai",
                        Price = "360.000.000 VNĐ",
                        Picture = "Assets/hyundai_grand_i10.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai Elantra",
                        Manufacturer = "Hyundai",
                        Price = "579.000.000 VNĐ",
                        Picture = "Assets/hyundai_elantra.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai Tucson",
                        Manufacturer = "Hyundai",
                        Price = "769.000.000 VNĐ",
                        Picture = "Assets/hyundai_tucson.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai IONIQ 5",
                        Manufacturer = "Hyundai",
                        Price = "1.300.000.000 VNĐ",
                        Picture = "Assets/hyundai_ioniq_5.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "Hyundai Solati",
                        Manufacturer = "Hyundai",
                        Price = "1.080.000.000 VNĐ",
                        Picture = "Assets/hyundai_solati.png",
                        Condition = "Xe cu"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "KIA",
                ManufacturerPicture = "Assets/kia_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "KIA Carens",
                        Manufacturer = "Kia",
                        Price = "589.000.000 VNĐ",
                        Picture = "Assets/kia_carens.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "KIA Sportage",
                        Manufacturer = "Kia",
                        Price = "779.000.000 VNĐ",
                        Picture = "Assets/kia_sportage.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "KIA Carnival",
                        Manufacturer = "Kia",
                        Price = "1.299.000.000 VNĐ",
                        Picture = "Assets/kia_carnival.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "KIA Sonet",
                        Manufacturer = "Kia",
                        Price = "539.000.000 VNĐ",
                        Picture = "Assets/kia_sonet.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "KIA K5",
                        Manufacturer = "Kia",
                        Price = "859.000.000 VNĐ",
                        Picture = "Assets/kia_k5.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "KIA Morning",
                        Manufacturer = "Kia",
                        Price = "349.000.000 VNĐ",
                        Picture = "Assets/kia_morning.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "KIA Seltos",
                        Manufacturer = "Kia",
                        Price = "599.000.000 VNĐ",
                        Picture = "Assets/kia_seltos.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "KIA Soluto",
                        Manufacturer = "Kia",
                        Price = "386.000.000 VNĐ",
                        Picture = "Assets/kia_soluto.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "KIA K3",
                        Manufacturer = "Kia",
                        Price = "549.000.000 VNĐ",
                        Picture = "Assets/kia_k3.png",
                        Condition = "Xe cu"
                    },
                    new Cars()
                    {
                        Model = "KIA Sorento",
                        Manufacturer = "Kia",
                        Price = "964.000.000 VNĐ",
                        Picture = "Assets/kia_sorento.png",
                        Condition = "Xe cu"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Subaru",
                ManufacturerPicture = "Assets/subaru_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "Forester 2.0i-L",
                        Manufacturer = "Subaru",
                        Price = "869.000.000 VNĐ",
                        Picture = "Assets/subaru_forester_2.0i_l.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Forester 2.0i-L EyeSight",
                        Manufacturer = "Subaru",
                        Price = "929.000.000 VNĐ",
                        Picture = "Assets/subaru_forester_2.0i_l_eyesight.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Forester 2.0i-S EyeSight",
                        Manufacturer = "Subaru",
                        Price = "969.000.000 VNĐ",
                        Picture = "Assets/subaru_forester_2.0i_s_eyesight.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Crosstrek 2.0i-S EyeSight",
                        Manufacturer = "Subaru",
                        Price = "999.000.000 VNĐ",
                        Picture = "Assets/subaru_crosstrek_2.0i_s_eyesight.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Outback 2.5i-T EyeSight",
                        Manufacturer = "Subaru",
                        Price = "1.696.000.000 VNĐ",
                        Picture = "Assets/subaru_outback_2.5i_t_eyesight.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BRZ 6AT EyeSight",
                        Manufacturer = "Subaru",
                        Price = "1.535.000.000 VNĐ",
                        Picture = "Assets/subaru_brz_6at_eyesight.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "WRX 2.4 Sedan",
                        Manufacturer = "Subaru",
                        Price = "1.690.000.000 VNĐ",
                        Picture = "Assets/subaru_wrx_2.4_sedan.png",
                        Condition = "Xe moi"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Mercedes Benz",
                ManufacturerPicture = "Assets/mercedes_benz_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "Mercedes C-Class",
                        Manufacturer = "Mercedes Benz",
                        Price = "1.388.000.000 VNĐ",
                        Picture = "Assets/mercedes_c_class.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mercedes E-Class",
                        Manufacturer = "Mercedes Benz",
                        Price = "1.888.000.000 VNĐ",
                        Picture = "Assets/mercedes_e_class.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mercedes-Benz GLC-Class",
                        Manufacturer = "Mercedes Benz",
                        Price = "2.299.000.000 VNĐ",
                        Picture = "Assets/mercedes_benz_glc_class.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "EQS 500 4Matic",
                        Manufacturer = "Mercedes Benz",
                        Price = "4.999.000.000 VNĐ",
                        Picture = "Assets/mercedes_benz_eqs_500_4matic.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "EQE 500 4Matic",
                        Manufacturer = "Mercedes Benz",
                        Price = "3.999.000.000 VNĐ",
                        Picture = "Assets/mercedes_benz_eqe_500_4matic.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mercedes-Benz EQB 250",
                        Manufacturer = "Mercedes Benz",
                        Price = "2.289.000.000 VNĐ",
                        Picture = "Assets/mercedes_benz_eqb_250.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mercedes-Benz EQS",
                        Manufacturer = "Mercedes Benz",
                        Price = "4.839.000.000 VNĐ",
                        Picture = "Assets/mercedes_benz_eqs.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mercedes S450",
                        Manufacturer = "Mercedes Benz",
                        Price = "5.039.000.000 VNĐ",
                        Picture = "Assets/mercedes_s450.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mercedes GLB",
                        Manufacturer = "Mercedes Benz",
                        Price = "1.658.000.000 VNĐ",
                        Picture = "Assets/mercedes_glb.png",
                        Condition = "Xe moi"
                    },

                }
            },
            new Manufacturers()
            {
                ManufacturerName = "BMW",
                ManufacturerPicture = "Assets/bmw_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "BMW XM",
                        Manufacturer = "BMW",
                        Price = "10.099.000.000 VNĐ",
                        Picture = "Assets/bmw_xm.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW iX3",
                        Manufacturer = "BMW",
                        Price = "3.479.000.000 VNĐ",
                        Picture = "Assets/bmw_ix3.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW i4",
                        Manufacturer = "BMW",
                        Price = "3.739.000.000 VNĐ",
                        Picture = "Assets/bmw_i4.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW X7",
                        Manufacturer = "BMW",
                        Price = "5.149.000.000 VNĐ",
                        Picture = "Assets/bmw_x7.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW 7-Series",
                        Manufacturer = "BMW",
                        Price = "4.499.000.000 VNĐ",
                        Picture = "Assets/bmw_7_series.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW 5-Series",
                        Manufacturer = "BMW",
                        Price = "1.829.000.000 VNĐ",
                        Picture = "Assets/bmw_5_series.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW X4",
                        Manufacturer = "BMW",
                        Price = "2.899.000.000 VNĐ",
                        Picture = "Assets/bmw_x4.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW 3-Series",
                        Manufacturer = "BMW",
                        Price = "1.499.000.000 VNĐ",
                        Picture = "Assets/bmw_3_series.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW 4-Series",
                        Manufacturer = "BMW",
                        Price = "2.629.000.000 VNĐ",
                        Picture = "Assets/bmw_4_series.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW X3",
                        Manufacturer = "BMW",
                        Price = "1.855.000.000 VNĐ",
                        Picture = "Assets/bmw_x3.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW X5",
                        Manufacturer = "BMW",
                        Price = "3.909.000.000 VNĐ",
                        Picture = "Assets/bmw_x5.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "BMW Z4 sDrive30i",
                        Manufacturer = "BMW",
                        Price = "3.139.000.000 VNĐ",
                        Picture = "Assets/bmw_z4_sdrive30i.png",
                        Condition = "Xe moi"
                    }

                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Lexus",
                ManufacturerPicture = "Assets/lexus_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "Lexus NX",
                        Manufacturer = "Lexus",
                        Price = "3.130.000.000 VNĐ",
                        Picture = "Assets/lexus_nx.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Lexus LM 500h",
                        Manufacturer = "Lexus",
                        Price = "7.290.000.000 VNĐ",
                        Picture = "Assets/lexus_lm_500h.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Lexus IS",
                        Manufacturer = "Lexus",
                        Price = "2.130.000.000 VNĐ",
                        Picture = "Assets/lexus_is.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Lexus RX",
                        Manufacturer = "Lexus",
                        Price = "3.430.000.000 VNĐ",
                        Picture = "Assets/lexus_rx.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Lexus LX",
                        Manufacturer = "Lexus",
                        Price = "8.500.000.000 VNĐ",
                        Picture = "Assets/lexus_lx.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Lexus GX",
                        Manufacturer = "Lexus",
                        Price = "6.200.000.000 VNĐ",
                        Picture = "Assets/lexus_gx.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Lexus LS",
                        Manufacturer = "Lexus",
                        Price = "7.650.000.000 VNĐ",
                        Picture = "Assets/lexus_ls.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Lexus ES",
                        Manufacturer = "Lexus",
                        Price = "2.620.000.000 VNĐ",
                        Picture = "Assets/lexus_es.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Lexus RC",
                        Manufacturer = "Lexus",
                        Price = "3.290.000.000 VNĐ",
                        Picture = "Assets/lexus_rc.png",
                        Condition = "Xe moi"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Porsche",
                ManufacturerPicture = "Assets/porsche_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "Porsche 718",
                        Manufacturer = "Porsche",
                        Price = "3.620.000.000 VNĐ",
                        Picture = "Assets/porsche_718.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Porsche 911",
                        Manufacturer = "Porsche",
                        Price = "7.130.000.000 VNĐ",
                        Picture = "Assets/porsche_911.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Porsche Taycan",
                        Manufacturer = "Porsche",
                        Price = "4.170.000.000 VNĐ",
                        Picture = "Assets/porsche_taycan.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Porsche Panamera",
                        Manufacturer = "Porsche",
                        Price = "6.420.000.000 VNĐ",
                        Picture = "Assets/porsche_panamera.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Porsche Macan",
                        Manufacturer = "Porsche",
                        Price = "3.150.000.000 VNĐ",
                        Picture = "Assets/porsche_macan.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Porsche Cayenne",
                        Manufacturer = "Porsche",
                        Price = "5.560.000.000 VNĐ",
                        Picture = "Assets/porsche_cayenne.png",
                        Condition = "Xe moi"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "VinFast",
                ManufacturerPicture = "Assets/vinfast_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "VinFast VF 5",
                        Manufacturer = "VinFast",
                        Price = "460.000.000 VNĐ",
                        Picture = "Assets/vinfast_vf_5.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "VinFast VF 6",
                        Manufacturer = "VinFast",
                        Price = "675.000.000 VNĐ",
                        Picture = "Assets/vinfast_vf_6.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "VinFast VF 7",
                        Manufacturer = "VinFast",
                        Price = "850.000.000 VNĐ",
                        Picture = "Assets/vinfast_vf_7.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "VinFast VF 8",
                        Manufacturer = "VinFast",
                        Price = "1.079.000.000 VNĐ",
                        Picture = "Assets/vinfast_vf_8.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "VinFast VF 9",
                        Manufacturer = "VinFast",
                        Price = "1.531.000.000 VNĐ",
                        Picture = "Assets/vinfast_vf_9.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "VinFast VF e34",
                        Manufacturer = "VinFast",
                        Price = "710.000.000 VNĐ",
                        Picture = "Assets/vinfast_vf_e34.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "VinFast VF 3",
                        Manufacturer = "VinFast",
                        Price = "240.000.000 VNĐ",
                        Picture = "Assets/vinfast_vf_3.png",
                        Condition = "Xe moi"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Mazda",
                ManufacturerPicture = "Assets/mazda_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "Mazda CX-3",
                        Manufacturer = "Mazda",
                        Price = "512.000.000 VNĐ",
                        Picture = "Assets/mazda_cx_3.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mazda CX-30",
                        Manufacturer = "Mazda",
                        Price = "699.000.000 VNĐ",
                        Picture = "Assets/mazda_cx_30.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mazda 6",
                        Manufacturer = "Mazda",
                        Price = "769.000.000 VNĐ",
                        Picture = "Assets/mazda_6.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mazda CX-5",
                        Manufacturer = "Mazda",
                        Price = "749.000.000 VNĐ",
                        Picture = "Assets/mazda_cx_5.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mazda CX-8",
                        Manufacturer = "Mazda",
                        Price = "949.000.000 VNĐ",
                        Picture = "Assets/mazda_cx_8.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mazda 2",
                        Manufacturer = "Mazda",
                        Price = "408.000.000 VNĐ",
                        Picture = "Assets/mazda_2.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mazda 3",
                        Manufacturer = "Mazda",
                        Price = "579.000.000 VNĐ",
                        Picture = "Assets/mazda_3.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Mazda BT 50",
                        Manufacturer = "Mazda",
                        Price = "554.000.000 VNĐ",
                        Picture = "Assets/mazda_bt_50.png",
                        Condition = "Xe moi"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Honda",
                ManufacturerPicture = "Assets/honda_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "Honda City",
                        Manufacturer = "Honda",
                        Price = "499.000.000 VNĐ",
                        Picture = "Assets/honda_city.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Honda BR-V",
                        Manufacturer = "Honda",
                        Price = "661.000.000 VNĐ",
                        Picture = "Assets/honda_br_v.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Honda CR-V",
                        Manufacturer = "Honda",
                        Price = "1.029.000.000 VNĐ",
                        Picture = "Assets/honda_cr_v.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Honda Accord",
                        Manufacturer = "Honda",
                        Price = "1.319.000.000 VNĐ",
                        Picture = "Assets/honda_accord.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Honda Civic",
                        Manufacturer = "Honda",
                        Price = "730.000.000 VNĐ",
                        Picture = "Assets/honda_civic.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Honda Civic Type R",
                        Manufacturer = "Honda",
                        Price = "2.399.000.000 VNĐ",
                        Picture = "Assets/honda_civic_type_r.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Honda HR-V",
                        Manufacturer = "Honda",
                        Price = "699.000.000 VNĐ",
                        Picture = "Assets/honda_hr_v.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Honda Brio",
                        Manufacturer = "Honda",
                        Price = "418.000.000 VNĐ",
                        Picture = "Assets/honda_brio.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Honda Jazz",
                        Manufacturer = "Honda",
                        Price = "544.000.000 VNĐ",
                        Picture = "Assets/honda_jazz.png",
                        Condition = "Xe moi"
                    }
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Audi",
                ManufacturerPicture = "Assets/audi_logo.jpg",
                Cars = new List<Cars>
                {
                    new Cars()
                    {
                        Model = "Audi Q8 e-tron",
                        Manufacturer = "Audi",
                        Price = "3.800.000.000 VNĐ",
                        Picture = "Assets/audi_q8_e_tron.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Audi e-tron GT",
                        Manufacturer = "Audi",
                        Price = "5.200.000.000 VNĐ",
                        Picture = "Assets/audi_e_tron_gt.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Audi Q3",
                        Manufacturer = "Audi",
                        Price = "1.890.000.000 VNĐ",
                        Picture = "Assets/audi_q3.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Audi Q5",
                        Manufacturer = "Audi",
                        Price = "2.390.000.000 VNĐ",
                        Picture = "Assets/audi_q5.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Audi Q7",
                        Manufacturer = "Audi",
                        Price = "3.590.000.000 VNĐ",
                        Picture = "Assets/audi_q7.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Audi A6",
                        Manufacturer = "Audi",
                        Price = "2.500.000.000 VNĐ",
                        Picture = "Assets/audi_a6.png",
                        Condition = "Xe moi"
                    },
                    new Cars()
                    {
                        Model = "Audi Q2",
                        Manufacturer = "Audi",
                        Price = "1.590.000.000 VNĐ",
                        Picture = "Assets/audi_q2.png",
                        Condition = "Xe moi"
                    }
                }
            },
        };
        return result;
    }

    public List<Users> GetUsers()
    {
        var users = new List<Users>()
        {
            new Users() { Username = "admin", Password = "123" },
            new Users() { Username = "lebao", Password = "hihi" }
        };
        return users;
    }
    public List<IsExpanderExpaned> GetIsExpanderExpaned()
    {
        var result = new List<IsExpanderExpaned>()
        {
            new IsExpanderExpaned()
            {
                isExpanderExpanded = true,
                toggleText = "Thu gọn",
            },
            new IsExpanderExpaned()
            {
                isExpanderExpanded = true,
                toggleText = "Thu gọn",
            },
            new IsExpanderExpaned()
            {
                isExpanderExpanded = true,
                toggleText = "Thu gọn",
            },
        };
        return result;
    }

    public List<Location> GetLocations()
    {
        var result = new List<Location>()
        {
            new Location()
            {
                City = "Hà Nội",
                District = new List<string>()
                {
                    "Ba Đình",
                    "Hoàn Kiếm",
                    "Hai Bà Trưng",
                    "Đống Đa",
                    "Tây Hồ",
                    "Cầu Giấy",
                    "Thanh Xuân",
                    "Hoàng Mai",
                    "Long Biên",
                    "Bắc Từ Liêm",
                    "Nam Từ Liêm",
                    "Hà Đông",
                    "Sơn Tây",
                    "Ba Vì",
                    "Phúc Thọ",
                    "Thạch Thất",
                    "Quốc Oai",
                    "Chương Mỹ",
                    "Thanh Oai",
                    "Thường Tín",
                    "Phú Xuyên",
                    "Ứng Hòa",
                    "Mỹ Đức"
                }
            },
            new Location()
            {
                City = "Hồ Chí Minh",
                District = new List<string>()
                {
                    "Quận 1",
                    "Quận 2",
                    "Quận 3",
                    "Quận 4",
                    "Quận 5",
                    "Quận 6",
                    "Quận 7",
                    "Quận 8",
                    "Quận 9",
                    "Quận 10",
                    "Quận 11",
                    "Quận 12",
                    "Quận Bình Tân",
                    "Quận Bình Thạnh",
                    "Quận Gò Vấp",
                    "Quận Phú Nhuận",
                    "Quận Tân Bình",
                    "Quận Tân Phú",
                    "Quận Thủ Đức",
                    "Huyện Bình Chánh",
                    "Huyện Cần Giờ",
                    "Huyện Củ Chi",
                    "Huyện Hóc Môn",
                    "Huyện Nhà Bè"
                }
            },
            new Location()
            {
                City = "Đà Nẵng",
                District = new List<string>()
                {
                     "Quận Hải Châu",
                    "Quận Thanh Khê",
                    "Quận Sơn Trà",
                    "Quận Ngũ Hành Sơn",
                    "Quận Liên Chiểu",
                    "Huyện Hoàng Sa"
                }
            },
        };
        return result;
    }
}
