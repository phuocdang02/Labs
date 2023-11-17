import { Layer } from "../models/layer.interface";
import { NavListModel } from "../models/navbar_interface";
import { Pin } from "../models/pin.interface";

export class HardCode {
    public static readonly NAV_LIST_ITEM: NavListModel[] = [
        {
            navId: 1,
            routerLink: 'open-street-map',
            icon: 'map',
            label: 'Open Street Map',
            layers: [],
        },
        {
            navId: 0,
            routerLink: 'gooogle-map',
            icon: 'map',
            label: 'Google Map',
            layers: [],
        },
        {
            navId: 99,
            routerLink: 'logout',
            icon: 'logout',
            label: 'Logout',
            layers: [],
        },
    ];

    /**
     * Call api to get Layer from type_map with user_id
     * with condition: type_map have to value in license list
     * @param: body {"user_id":"1","type_map_id": "1"}
     */
    public static readonly MY_LAYERS_GM: Layer[] = [
        {
            layer_id: "1",
            layer_name: "District 1",
            type_map: {
                type_map_id: "0",
                type_map_name: "google map",
            },
            latitude: 10.77791,
            longitude: 106.696596,
            zoom: 17,
            status: "active",
            camera_default_id: "1",
        },
        {
            layer_id: "2",
            layer_name: "District 2",
            type_map: {
                type_map_id: "0",
                type_map_name: "google map",
            },
            latitude: 10.769785,
            longitude: 106.72374,
            zoom: 17,
            status: "working",
            camera_default_id:"6",
        },
        {
            layer_id: "3",
            layer_name: "District 7",
            type_map: {
                type_map_id: "0",
                type_map_name: "google map",
            },
            latitude: 10.72583,
            longitude: 106.714637,
            zoom: 17,
            status: "working",
            camera_default_id:"11",
        }
    ];
    public static readonly MY_LAYERS_OSM: Layer[] = [
        {
            layer_id: "4",
            layer_name: "Phú Mỹ Hưng - Khu Văn Hóa Giải Trí",
            type_map: {
                type_map_id: "1",
                type_map_name: "open street map",
            },
            latitude: 10.732011,
            longitude: 106.710028,
            zoom: 17,
            status: "active",
            camera_default_id:"16",
        },
        {
            layer_id: "5",
            layer_name: "Phú Mỹ Hưng - Khu Y Tế Điều Dưỡng",
            type_map: {
                type_map_id: "1",
                type_map_name: "open street map",
            },
            latitude: 10.7329338,
            longitude: 106.718344,
            zoom: 17,
            status: "working",
            camera_default_id:"21",
        },
        {
            layer_id: "6",
            layer_name: "Phú Mỹ Hưng - Khu Thương Mại Tài Chính Quốc Tế	",
            type_map: {
                type_map_id: "1",
                type_map_name: "open street map",
            },
            latitude: 10.7291081,
            longitude: 106.72288,
            zoom: 16,
            status: "working",
            camera_default_id:"26",
        }
    ];
    public static readonly MY_LAYERS_IM: Layer[] = [
        {
            layer_id: "7",
            layer_name: "Longitudinal Section",
            type_map: {
                type_map_id: "2",
                type_map_name: "interior map",
            },
            latitude: 0,
            longitude: 0,
            zoom: 1,
            status: "active",
            source: "../../assets/images/matcatdoc.png",
            camera_default_id: "cross_F0",
            height:684,
            width:845,
        },
        {
            layer_id: "8",
            layer_name: "Ground Floor",
            type_map: {
                type_map_id: "2",
                type_map_name: "interior map",
            },
            latitude: 0,
            longitude: 0,
            zoom: 1,
            status: "working",
            source: "../../assets/images/tangtret.png",
            camera_default_id: "floor_tret_R1",
            height:702,
            width:1498,
        },
        {
            layer_id: "9",
            layer_name: "1st Floor",
            type_map: {
                type_map_id: "2",
                type_map_name: "interior map",
            },
            latitude: 0,
            longitude: 0,
            zoom: 1,
            status: "working",
            source: "../../assets/images/tang1.png",
            camera_default_id: "floor_1_R3",
            height:686,
            width:1466,
        },
        {
            layer_id: "10",
            layer_name: "2nd Floor",
            type_map: {
                type_map_id: "2",
                type_map_name: "interior map",
            },
            latitude: 0,
            longitude: 0,
            zoom: 1,
            status: "working",
            source: "../../assets/images/tang2.png",
            camera_default_id: "floor_2_R2",
            height:736,
            width:1450,
        }
    ];

    /**
     * Get Cameras From Layer
     * @param: body {"user_id":"1","layer_id":"0"}
     */
    public static readonly MY_CAMERAS: Pin[] = [
        {
            "cameraId": "1",
            name: "Camera Alexandre de Rhodes",
            latitude: 10.778968,
            longitude: 106.696054,
            cameraIp: "123456DSDGSDF",
            status: "live",
            source: "assets/videos/video1.mp4",
            layer_id:"1"
        },
        {
            cameraId: "2",
            name: "Camera Nguyen Du",
            latitude: 10.780097,
            longitude: 106.700708,
            cameraIp: "AGRGV45DG45",
            status: "live",
            source: "assets/videos/video2.mp4",
            layer_id:"1",
        },
        {
            cameraId: "3",
            name: "Camera Ly Tu Trong",
            latitude: 10.777776,
            longitude: 106.700931,
            cameraIp: "123456DSHHHDF",
            status: "live",
            source: "assets/videos/video3.mp4",
            layer_id:"1",
        },
        {
            cameraId: "4",
            name: "Camera Le Thanh Ton",
            latitude: 10.774485,
            longitude: 106.699163,
            cameraIp: "AGRGV45DYY5",
            status: "live",
            source: "assets/videos/video4.mp4",
            layer_id:"1",
        },
        {
            cameraId: "5",
            name: "Camera Truong Dinh",
            latitude: 10.775959,
            longitude: 106.691996,
            cameraIp: "AGR22V45DYY5",
            status: "live",
            source: "assets/videos/video1.mp4",
            layer_id:"1",
        },
        {
            cameraId: "6",
            name: "Camera D6",
            latitude: 10.771763,
            longitude: 106.721244,
            cameraIp: "AGRG23445DYY5",
            status: "live",
            source: "assets/videos/video2.mp4",
            layer_id:"2",
        },
        {
            cameraId: "7",
            name: "Camera Hoang The Thien",
            latitude: 10.768545,
            longitude: 106.721099,
            cameraIp: "AGRG23455DYY5",
            status: "live",
            source: "assets/videos/video3.mp4",
            layer_id:"2",
        },
        {
            cameraId: "8",
            name: "Camera N7",
            latitude: 10.768701,
            longitude: 106.723899,
            cameraIp: "AGRG23455DRY5",
            status: "live",
            source: "assets/videos/video4.mp4",
            layer_id:"2",
        },
        {
            cameraId: "9",
            name: "Camera So 10",
            latitude: 10.771715,
            longitude: 106.725830,
            cameraIp: "BGRG23455DRY5",
            status: "live",
            source: "assets/videos/video1.mp4",
            layer_id:"2",
        },
        {
            cameraId: "10",
            name: "Camera Camera Hoang The Thien 2",
            latitude: 10.772815,
            longitude: 106.724513,
            cameraIp: "BGRG23455DRY5",
            status: "live",
            source: "assets/videos/video2.mp4",
            layer_id:"2",
        },
        {
            cameraId: "11",
            name: "Camera Ton Dat Tien",
            latitude: 10.724064,
            longitude: 106.716062,
            cameraIp: "ZGRG23455DRY5",
            status: "live",
            source: "assets/videos/video3.mp4",
            layer_id:"3",
        },
        {
            cameraId: "12",
            name: "Camera N-Nam",
            latitude: 10.726675,
            longitude: 106.715861,
            cameraIp: "ZGRG23455D5Y5",
            status: "live",
            source: "assets/videos/video4.mp4",
            layer_id:"3",
        },
        {
            cameraId: "13",
            name: "Camera Nguyen Cao",
            latitude: 10.723416,
            longitude: 106.712436,
            cameraIp: "ZGRG23455DTY5",
            status: "live",
            source: "assets/videos/video1.mp4",
            layer_id:"3",
        },
        {
            cameraId: "14",
            name: "Camera Phu Gia",
            latitude: 10.725126,
            longitude: 106.714221,
            cameraIp: "ZGRG234555TY5",
            status: "live",
            source: "assets/videos/video2.mp4",
            layer_id:"3",
        },
        {
            cameraId: "15",
            name: "Camera Ha Huy Tap",
            latitude: 10.726582,
            longitude: 106.712343,
            cameraIp: "ZGRG23455D545",
            status: "live",
            source: "assets/videos/video3.mp4",
            layer_id:"3",
        },
        {
            cameraId: "16",
            name: "Camera Pham Van Nghi - Nguyen Van Linh",
            latitude: 10.729310,
            longitude: 106.706792,
            cameraIp: "ZGRG23455D5P45",
            status: "live",
            source: "assets/videos/video4.mp4",
            layer_id:"4",
        },
        {
            cameraId: "17",
            name: "Camera Dang Dai Do - Nguyen Van Linh",
            latitude: 10.729419,
            longitude: 106.710409,
            cameraIp: "ZGRG23455D5P45",
            status: "live",
            source: "assets/videos/video1.mp4",
            layer_id:"4",
        },
        {
            cameraId: "18",
            name: "Camera Hung Gia 4",
            latitude: 10.732310,
            longitude: 106.706205,
            cameraIp: "ZGRG23455D5P45",
            status: "live",
            source: "assets/videos/video2.mp4",
            layer_id:"4",
        },
        {
            cameraId: "19",
            name: "Camera Cao Trieu Phat",
            latitude: 10.732025,
            longitude: 106.711162,
            cameraIp: "ZGRG23455D5P45",
            status: "live",
            source: "assets/videos/video3.mp4",
            layer_id:"4",
        },
        {
            cameraId: "20",
            name: "Camera Hung Thai 2 - Bui Bang Doan",
            latitude: 10.734655,
            longitude: 106.708393,
            cameraIp: "ZGRG23455D5YY45",
            status: "live",
            source: "assets/videos/video4.mp4",
            layer_id:"4",
        },
        {
            cameraId: "21",
            name: "Camera Nguyen Luong Bang - Nguyen Van Linh",
            latitude: 10.731996,
            longitude: 106.719729,
            cameraIp: "ZGRG23455DTT45",
            status: "live",
            source: "assets/videos/video1.mp4",
            layer_id:"5",
        },
        {
            cameraId: "22",
            name: "Camera Ton Dat Tien - Thung Lung Xanh",
            latitude: 10.730826,
            longitude: 106.717733,
            cameraIp: "ZGRG23455D3T45",
            status: "live",
            source: "assets/videos/video2.mp4",
            layer_id:"5",
        },
        {
            cameraId: "23",
            name: "Camera Nguyen Dong Chi - Nguyen Luong Bang",
            latitude: 10.733915,
            longitude: 106.718409,
            cameraIp: "ZGRG23455D3T05",
            status: "live",
            source: "assets/videos/video3.mp4",
            layer_id:"5",
        },
        {
            cameraId: "24",
            name: "Camera Nguyen Dong Chi - Ton Dat Tien",
            latitude: 10.734052,
            longitude: 106.713560,
            cameraIp: "ZGRG23455D9T05",
            status: "live",
            source: "assets/videos/video4.mp4",
            layer_id:"5",
        },
        {
            cameraId: "25",
            name: "Camera Thung Lung Xanh - Quan Am Bo Tat",
            latitude: 10.731522,
            longitude: 106.717455,
            cameraIp: "ZGRG2M455D9T05",
            status: "live",
            source: "assets/videos/video1.mp4",
            layer_id:"5",
        },
        {
            cameraId: "26",
            name: "Camera Nguyen Van Linh - Nguyen Luong Bang",
            latitude: 10.730942,
            longitude: 106.720412,
            cameraIp: "ZGRGMM455D9T05",
            status: "live",
            source: "assets/videos/video2.mp4",
            layer_id:"6",
        },
        {
            cameraId: "27",
            name: "Camera Tan Phu - Hoang Van Thai",
            latitude: 10.732209,
            longitude: 106.725423,
            cameraIp: "ZGRGMP455D9T05",
            status: "live",
            source: "assets/videos/video3.mp4",
            layer_id:"6",
        },
        {
            cameraId: "28",
            name: "Camera Tan Phu - Raymondienne",
            latitude: 10.729169,
            longitude: 106.727210,
            cameraIp: "Z44GMP455D9T05",
            status: "live",
            source: "assets/videos/video4.mp4",
            layer_id:"6",
        },
        {
            cameraId: "29",
            name: "Camera Nguyen Luong Bang - Tran Van Tra",
            latitude: 10.725570,
            longitude: 106.723609,
            cameraIp: "Z44GMP455DUU05",
            status: "live",
            source: "assets/videos/video1.mp4",
            layer_id:"6",
        },
        {
            cameraId: "30",
            name: "Camera Ton Dat Tien - Morison",
            latitude: 10.726596,
            longitude: 106.720201,
            cameraIp: "Z44GMP45577U05",
            status: "live",
            source: "assets/videos/video2.mp4",
            layer_id:"6",
        },
        {
            cameraId: "cross_F1",
            name: "1st Floor Balcony",
            latitude: 212.19730941704037,
            longitude: 289.6346356916579,
            cameraIp: 'AGRGVBBBSBBF68',
            status: 'live',
            source:'assets/videos/tang1_ban_cong.mp4',
            layer_id:"7",
        },
        {
            cameraId: "cross_F2",
            name: "2nd Floor Balcony",
            latitude: 257.63724035608305,
            longitude: 179.12565997888066,
            cameraIp: 'AGRGV2455RT57',
            status: 'live',
            source:'assets/videos/tang2_ban_cong.mp4',
            layer_id:"7",
        },
        {
            cameraId: "cross_F0",
            name: "Main Door",
            latitude: 203.98729446935727,
            longitude: 394.3653643083421,
            cameraIp: 'AGRGV45DG4346',
            status: 'live',
            source:'assets/videos/tret_cua.mp4', 
            layer_id:"7",
        },
        {
            cameraId: "floor_tret_R1",
            name: "Main Door",
            latitude: 1331.4527486102531,
            longitude: 183.83949313621966,
            cameraIp: 'AGRGV45444DG46',
            status: 'live',
            source:'assets/videos/tret_cua.mp4',
            layer_id:"8",
        },
        {
            cameraId: "floor_tret_R2",
            name: "Garage",
            latitude: 950.6988130563798,
            longitude: 294.29144667370645,
            cameraIp: 'AGRGV45TTTTTRG57',
            status: 'live',
            source:'assets/videos/tret_nha_xe.mp4',
            layer_id:"8",
        },
        {
            cameraId: "floor_tret_R3",
            name: "Dining Room",
            latitude: 359.16617210682494,
            longitude: 369.90285110876454,
            cameraIp: 'AGRGYYYYDG68',
            status: 'live',
            source:'assets/videos/tret_phong_an.mp4',
            layer_id:"8",
        },
        {
            cameraId: "floor_1_R1",
            name: "Living Room",
            latitude: 339.56145768993207,
            longitude: 202.10559662090813,
            cameraIp: 'AGRGV45AADF46',
            status: 'live',
            source:'assets/videos/tang1_phong_khach.mp4',
            layer_id:"9",
        },
        {
            cameraId: "floor_1_R2",
            name: "Bed room",
            latitude: 999.8842729970327,
            longitude: 266.5765575501584,
            cameraIp: 'AGRGV45GGDF57',
            status: 'live',
            source:'assets/videos/tang1_phong_ngu.mp4',
            layer_id:"9",
        },
        {
            cameraId: "floor_1_R3",
            name: "1st Floor Balcony",
            latitude: 1234.3545994065282,
            longitude: 321.63041182682156,
            cameraIp: 'AGRGV45DVVF68',
            status: 'live',
            source:'assets/videos/tang1_ban_cong.mp4', 
            layer_id:"9",
        },
        {
            cameraId: "floor_2_R1",
            name: "Kid Room 2",
            latitude: 558.9688427299703,
            longitude: 224.60823653643084,
            cameraIp: 'AGRGV45RTBBB46',
            status: 'live',
            source:'assets/videos/tang2_phong_ngu_2.mp4',
            layer_id:"10",
        },
        {
            cameraId: "floor_2_R2",
            name: "2nd Floor Balcony",
            latitude: 1226.09635577517,
            longitude: 330.3062302006336,
            cameraIp: 'AGRGV45R444T57',
            status: 'live',
            source:'assets/videos/tang2_ban_cong.mp4',
            layer_id:"10",
        },
        {
            cameraId: "floor_2_R3",
            name: "Kid Room 1",
            latitude: 893.8798219584569,
            longitude: 225.38542766631468,
            cameraIp: 'AGRGV454544RT68',
            status: 'live',
            source:'assets/videos/tang2_phong_ngu.mp4', 
            layer_id:"10",
        },
    ];

    /**
     * Get Layer from type_map
     * @param: body {"user_id":"1","type_map":0}
     */
    public static readonly MY_LAYER = {
        "data": [
            {
                layer_id: "0",
                layer_name: "District 4",
                type_map: {
                    type_map_id:"1",
                    type_map_name:"open street map",
                },
                latitude: 10.7696,
                longitude: 106.6943,
                limit_zone: {
                    southWest_lat: 10.77285605647973,
                    southWest_lng: 106.69005632400514,
                    northEast_lat: 10.76446629854693,
                    northEast_lng: 106.69831752777101,
                },
                zoom: 17,
                status: "active",
                cameras: [
                    {
                        cameraId: "0",
                        name: "Camera A",
                        latitude: 10.77075,
                        longitude: 106.69535,
                        cameraIp: "123456DSDGSDF",
                        status: "live",
                        source: "assets/videos/live_video.mp4",
                    },
                    {
                        cameraId: "1",
                        name: "Camera B",
                        latitude: 10.76943,
                        longitude: 106.69533,
                        cameraIp: "AGRGV45DG45",
                        status: "live",
                        source: "assets/videos/live_video.mp4",
                    },
                ],
            },
            {
                layer_id: "1",
                layer_name: "District 12",
                type_map: {
                    type_map_id: "1",
                    type_map_name: "open street map",
                },
                latitude: 10.86818,
                longitude: 106.64825,
                zoom: 16,
                status: "working",

            }
        ],
    }

    /**
     * Call api check license
     * @param: body {"user_id":"1", license_id":"1"}
     * type_map have value below
     * 0    : Google Map
     * 1    : Open Street Map
     * 2    : Architectural Map
     * n    : Add other Map by change n
     */
    public static readonly MY_LICENSE = {
        license_id: "45",
        type_map: [
            {
                type_map_id: "0",
                type_map_name: "google map",
                createdAt: "2023-09-12T03:59:23Z",
                expiredAt: "2024-09-12T03:59:23Z"
            },
            {
                type_map_id: "1",
                type_map_name: "open street map",
                createdAt: "2023-09-12T03:59:23Z",
                expiredAt: "2024-09-12T03:59:23Z"
            },
            {
                type_map_id: "2",
                type_map_name: "architectural map",
                createdAt: "2023-09-12T03:59:23Z",
                expiredAt: "2024-09-12T03:59:23Z"
            }
        ],
    };

    /**
     * call api to get info user
     * @param: body {"user_id":"1"}
     */
    public static readonly USER_INFO = {
        user_id: "123AV-SD234-234AF",
        username: "Cụ Hồ",
        dob: "2023-09-12T03:59:23Z",
        gender: "female",
        fullname: "Hồ Gươm",
        phone_number: "906800014",
        email: "abc@mmsofts.com",
        password: "123",
        avatar: "https://media.istockphoto.com/id/1322277517/vi/anh/c%E1%BB%8F-d%E1%BA%A1i-tr%C3%AAn-n%C3%BAi-l%C3%BAc-ho%C3%A0ng-h%C3%B4n.jpg?s=612x612&w=0&k=20&c=ng_7l3FyBObY5ZJq2BgWCkOKct9Qk6ITFnCC2r55IKQ=",
        role_id: "1",
        license_id: "45",
    };


    /**
     * some hard code have type
     */

    /**
     * Get one Layer from layer_id
     * type_map: int
     * 0: google map
     * 1: open street map
     * property source to get link image if it is interior map
     * @param: body {"user_id":"1","layer_id":0}
     */
    public static readonly MAP_LAYER: Layer = {
        layer_id: "0",
        layer_name: "District 4",
        latitude: 10.7696,
        longitude: 106.6943,
        zoom: 17,
        status: "active",
    }
 

    /**
     * Get Layer is image a zone of a floor from layer_id (get layer_id in marker)
     * type_map: int
     * 0: google map
     * 1: open street map
     * property source to get link image if it is interior map
     * @param: body {"user_id":"1","layer_id":0}
     */
    public static readonly FLOOR_LAYER: Layer = {
        layer_id: "3",
        layer_name: "Interior zone of a floor",
        latitude: 10.86818,
        longitude: 106.64825,
        zoom: 15,
        status: "working",
        source: "https://nhataday.com/wp-content/uploads/2016/06/mat-bang-thiet-ke-chung-cu-109-nguyen-tuan-the-legend-tower-t-6.jpg",
        bounds:{
            northEast_lat:  10.878273699608496,
            northEast_lng: 106.66816271972657,
            southWest_lat: 10.858085958978645,
            southWest_lng:106.62833728027344,

        },  
        camera_default_id: "2",

    }

    /**
     * Get Cameras/Marker From Layer
     * @param: body {"user_id":"1","layer_id":"0"}
     */
    public static readonly MAP_PINS: Pin[] =
        [
            {
                cameraId: "1",
                name: "MAP_PINS A",
                latitude: 10.76943,
                longitude: 106.69533,
                cameraIp: "AGRGV45DG45",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "0",
            },
            {
                cameraId: "2",
                name: "MAP_PINS B",
                latitude: 10.77075,
                longitude: 106.69535,
                cameraIp: "123456DSDGSDF",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "0",
            },
            {
                cameraId: "3",
                name: "MAP_PINS C",
                latitude: 10.766851,
                longitude:106.696304,
                cameraIp: "123456DSDGSDF",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "0",
            },
            {
                cameraId: "4",
                name: "MAP_PINS D",
                latitude: 10.766712,
                longitude: 106.69452 ,
                cameraIp: "123456DSDGSDF",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "0",
            },
            {
                cameraId: "5",
                name: "MAP_PINS E",
                latitude: 10.769966,
                longitude: 106.696307,
                cameraIp: "123456DSDGSDF",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "0",
            },
        ]

    /**
* Get Cameras/Marker From Layer building
* @param: body {"user_id":"1","layer_id":"2"}
*/
    public static readonly BUILD_PINS: Pin[] =
        [
            {
                // 10.866367733847483, f: 106.62968911361695}
                cameraId: "0",
                name: "BUILD_PINS A",
                latitude: 10.866367733847483,
                longitude: 106.62968911361695,
                cameraIp: "123456DSDGSDF",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "2",
            },
            {
                // 10.874628206587474, f: 106.6463402671814}
                cameraId: "1",
                name: "BUILD_PINS B",
                latitude: 10.874628206587474,
                longitude: 106.6463402671814,
                cameraIp: "AGRdsGV45DG45",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "2",
            },
            {
                cameraId: "2",
                name: "BUILD_PINS C",
                latitude: 10.86681866120144,
                longitude: 106.65535248947144,
                cameraIp: "AGRGfsV45DG45",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "2",
            },
        ]


    /**
     * Get Cameras/Marker From Layer building
     * @param: body {"user_id":"1","layer_id":"2"}
     */
    public static readonly FLOOR_PINS: Pin[] =
        [
            {
                //10.863543948378203, f: 106.66455783081055
                cameraId: "0",
                name: "FLOOR_PINS A",
                latitude: 10.863543948378203,
                longitude: 106.66455783081055,
                cameraIp: "123456DSDGSDF",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "3",
            },
            {
                //  : 10.869136670581181, f: 106.64492406082154
                cameraId: "1",
                name: "FLOOR_PINS B",
                latitude: 10.869094525116807,
                longitude: 106.64492406082154,
                cameraIp: "AGRGVfw45DG45",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "3",
            },
            {
                //  10.86681866120144, f: 106.65535248947144
                cameraId: "2",
                name: "FLOOR_PINS C",
                latitude: 10.86681866120144,
                longitude: 106.65535248947144,
                cameraIp: "AGRGV45erDG45",
                status: "live",
                source: "assets/videos/live_video.mp4",
                layer_id: "3",
            },
        ]
    public static readonly ALL_LAYER: Layer[] =
        [
            this.MAP_LAYER,
            // this.FLOOR_LAYER
        ]
}


