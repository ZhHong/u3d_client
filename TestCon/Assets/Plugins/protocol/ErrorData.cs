namespace app.protocol
{
    public enum ErrorData
    {
           //基础模块
    ACTION_FAILED = 0 ,//
    ACTION_SUCCESS = 1 ,//
    
    
    //通用模块110
    FUN_NOT_OPEN = 110000 ,//功能未开放
    INGOT_NOT_ENOUGH = 110001 ,//钻石不足
    COIN_NOT_ENOUGH = 110002 ,//金钱不够哦。
    LEVEL_NOT_ENOUGH = 110003 ,//等级不足哦~升级后再来吧！
    VIP_LEVEL_NOT_ENOUGH = 110004 ,//vip等级不够
    PACK_FULL = 110005 ,//包裹已满
    CREATE_ITEM_FAIL = 110006 ,//随机系统生成物品失败
    POWER_NOT_ENOUGH = 110007 ,//体力不足
    CHEQUE_NOT_ENOUGH = 110008 ,//粮饷不足
    IN_CD_TIME = 110009 ,//CD中
    POWER_FULL = 110010 ,//体力已满
    ENERGY_FULL = 110011 ,//技能点已满
    PLAYER_IS_NONE = 110012 ,//无法获取玩家信息
    CONFIG_ERROR = 110013 ,//配置项出错,请联系GM
    SYSTEM_BUSY = 110014 ,//系统繁忙，请稍后再试
    WORLD_LEVEL_NOT_ENOUGH = 110015 ,//世界等级不足
    DIALY_TIMES_NOT_ENOUGH = 110016 ,//今日次数已用完
    ENERGY_ENERGT_NOT_ENOUGH = 110017 ,//技能点不足
    VIP_UP_OR_LEVEL_UP = 110018 ,//提升VIP等级或者主角等级开启
    
    //运营平台 100
    PLATFORM_PARAM_INVALID = 100001 ,//运营服务器通信失败
    PLATFORM_NO_LOGIN = 100002 ,//还未成功登录
    PLATFORM_SERVER_NOFOUND = 100031 ,//游戏服务器不存在
    PLATFORM_SERVER_BUSY = 100032 ,//游戏服务器繁忙或无法连接
    PLATFORM_EXCEPTION = 100999 ,//业务服务器异常
    
    PLATFORM_PROTOCOL_INVALID = 100100 ,//运营平台通信异常
    PLATFORM_NO_USER = 100101 ,//用户名不存在
    PLATFORM_PWD_INCORRECT = 100102 ,//密码不正确
    PLATFORM_USER_LOCK = 100103 ,//账号被锁定,禁止登录
    PLATFORM_SESSION_INVALID = 100104 ,//Session不存在或不正确
    PLATFROM_CHECK_USERNAME_FAILED = 100105 ,//用户名应该是5-15之间的字母，数字和英文句号
    PLATFORM_USER_USERNAME_EXISTS = 100106 ,//用户名已存在
    PLATFORM_ITMEOUT = 100197 ,//平台连接超时
    PLATFORM_CONNECT_FAIL = 100198 ,//平台连接失败
    PLATFORM_UNKNOWN_ERROR = 100199 ,//未知错误
    
    PAYCENTER_ITUNES_TIMEOUT = 100201 ,//充值票据验证暂未通过，为保障您的利益，提示充值成功前请勿卸载游戏
    PAYCENTER_ITUNES_INVLIAD = 100202 ,//充值票据验证未通过，请确认itunes帐号正确，稍后再网络状况良好的环境下再次购买
    
    //登陆/创建角色 0
    CHECKNAME_DUPLICATE = 12 ,//名称已存在
    CHECKNAME_TOOLONG = 11 ,//名称长度非法
    CHECKNAME_ILLEGAG = 10 ,//名字包含敏感词汇，改名失败哦。
    LOGIN_NO_CHOSE_ROLE = 20 ,//还未选择角色
    
    //奖励0-54
    AWARD_RECEIVED = 540 ,//奖励以及领取或奖励不存在
    
    
    
    //道具 2
    ITEM_NO_EXIST = 2001 ,//物品不存在
    ITEM_CAN_NOT_UPGRADE = 2002 ,//物品不能升级
    ITEM_IS_MAX_LEV = 2003 ,//物品到达当前等级上限
    ITEM_SKILL_NO_EXIST = 2004 ,//技能不存在
    ITEM_SPENDITEM_ERROR = 2005 ,//用于消耗的物品错误
    ITEM_FULL = 2006 ,//物品数量已到上限
    ITEM_NOT_ENOUGH = 2007 ,//物品数量不足
    ITEM_UPGRADE_MAX = 2008 ,//物品已经强化到最高等级
    ITEM_CAN_NOT_REFINE = 2009 ,//物品品质不满足，不能用于精炼
    ITEM_REFINE_SAME = 2010 ,//属性相同，不能精炼
    ITEM_REFINE_TYPE_NOT = 2011 ,//装备的部位不同
    ITEM_MODIFY_NONE = 2012 ,//不能更改此装备没有的属性
    ITEM_MODIFY_LOCK_MAX = 2013 ,//超过最大的锁定条数
    ITEM_NORMAL_NOT_LOCK = 2014 ,//普通改装不能锁定属性
    ITEM_CAN_NOT_COMPOSE = 2015 ,//装备品质太低不能用于合成
    ITEM_REFINE_NOT_SAME = 2016 ,//属性不同，不能合成
    ITEM_EQUIP = 2017 ,//装备正在被使用
    ITEM_NO_TRANSFER = 2018 ,//装备不能传承
    ITEM_Q_MAX = 2019 ,//装备品质已经达到上限，不能再接受置换
    ITEM_RED_INGOT_NOT_ENOUGH = 2020 ,//强化水晶不足
    ITEM_NO_SELECT_INHERT_EQUIP = 2021 ,//请选择被传承装备
    EQUIP_NOT_ALLOW_REFINE = 2022 ,//已穿戴的装备无法精炼
    EQUIP_NOT_ALLOW_INHERT = 2023 ,//已穿戴的装备不能传承
    ITEM_NOT_EQUIP = 2024 ,//不是可以穿戴物品不能置换
    ITEM_USE_ONLY_ONE = 2025 ,//同一时间只能使用一次该物品
    ITEM_ADD_OR_UPDATE = 2100 ,//添加或改变物品
    ITEM_DEL = 2101 ,//删除物品
    ITEM_CAN_NOT_MODIFIED = 2095 ,//物品不能被改造
    ITEM_ATTR_NOT_ACTIVE = 2195 ,//物品等级附加属性未激活
    ITEM_REFINE_LEVEL_MAX = 2196 ,//觉醒等级已达上限
    ITEM_CAN_NOT_WEEK = 2197 ,//装备不能觉醒
    ITEM_BREAK_TO_MAX = 2198 ,//装备已达当前最高等级
    
    //任务模块 3(废弃)
    TASK_NOT_COMPLETE = 30001 ,//任务未完成
    TASK_DICE_OVER = 30002 ,//任务剧情未播放
    TASK_NOT_FOUND = 30003 ,//任务未找到
    
    //宠物模块3
    PET_ADD_OR_UPDATE = 3000 ,//宠物添加或更新
    PET_DEL = 3001 ,//宠物删除
    PET_NOT_EXITS = 3003 ,//宠物不存在
    PET_NOT_IN_DEPLOY = 3004 ,//宠物不在阵容中
    PET_HAS_IN_DEPLOY = 3005 ,//宠物已经上阵
    PET_INDEX_NOT_TRAIN = 3006 ,//最多只能训练4只宠物
    PET_INDEX_HAS_TRAIN = 3007 ,//已经有宠物在此训练
    PET_TRAIN_TIME_ERROR = 3008 ,//不能选择当前训练时间
    PET_TRAIN_EFFECT_ERROR = 3009 ,//不能选择当前训练效率
    PET_TRAINING = 3010 ,//宠物正在训练
    PET_NOT_VIP = 3011 ,//VIP等级不够
    PET_TIEM_EFFECT_SELECT = 3012 ,//请选择效率或时间
    PET_AMOUNT_MAX = 3013 ,//您的宠物数量已经达到上限
    PET_IS_FIGHTING = 3014 ,//宠物上阵中，无法出售
    PET_NOT_TRAINING = 3015 ,//该宠物没有训练
    PET_NOT_TIMES = 3016 ,//今日加速次数已经用完
    PET_MAX_LEVEL = 3017 ,//宠物等级不能超过部门等级
    PET_DEGREE_MAX = 3018 ,//宠物阶位达到上限
    PET_BREACH_MAX = 3019 ,//宠物已经达到突破上限
    PET_NOT_LEVEL = 3020 ,//宠物等级不足
    PET_NOT_SOUL = 3021 ,//宠物碎片不足
    PET_HAS_EXITS = 3022 ,//宠物已经存在
    PET_MAX_BREACH = 3023 ,//宠物突破次数已经达到上限
    PET_NOT_LIKE = 3024 ,//宠物并不喜欢这种食物！
    PET_FAVOR_MAX = 3025 ,//你和宠物已经融合成一体了！
    
    //副本模块 4
    MISSION_NOT_CONF = 4001 ,//配置文件中无此副本
    MISSION_SUB_NOT_CONF = 4002 ,//配置文件中无此子副本
    MISSION_NOT_OPEN = 4003 ,//副本还未开启
    MISSION_SUB_CD = 4004 ,//子副本还在cd
    MISSION_SUB_COMPLETE = 4005 ,//子副本已完成
    MISSION_NOT_BOSS = 4006 ,//还不能打BOSS关
    MISSION_ALREADY_RESET = 4007 ,//今天已经重置过副本了
    
    //聊天模块 6
    CHAT_NO_ENOUGH_SPEAKER = 6001 ,//木有喇叭
    
    //角色模块 8
    ROLE_NO_EXIST = 8001 ,//角色不存在
    ROLE_IS_MAX_LEV = 8002 ,//角色已到达当前等级上限
    ROLE_POTENTIAL_NOT_ENOUGH = 8003 ,//培训点不够啦。
    ROLE_RANK_NOT_ENOUGH = 8005 ,//角色阶位不足
    ROLE_RANK_IS_MAX = 8006 ,//等级不够哦
    ROLE_ADD_OR_UPDATE = 8100 ,//添加或改变角色
    ROLE_DEL = 8101 ,//删除角色
    ROLE_WORKS_NOT_ENOUGH = 8043 ,//晋阶需要的作品不足
    ROLE_WORKS_STAGE_NOT_ENOUGH = 8142 ,//晋阶需要的作品评价不满足
    ROLE_RELATION_HAS_BUILD = 8044 ,//已经与明星结交关系
    ROLE_RELATION_HAS_NOT_BUILD = 8045 ,//还未于明星结交
    ROLE_RELATION_NOT_BULID = 8046 ,//该明星不可以结交
    ROLE_RELATION_CACHE_NONE = 8047 ,//关系缓存数据异常
    ROLE_RELATION_DRINK_TYPE_ERROR = 8048 ,//请喝酒的类型错误
    ROLE_RELATION_COUNT_MAX = 8049 ,//结交明星达到上限
    ROLE_RELATION_MINE = 8050 ,//不能和自己结交
    ROLE_WORK_NONE = 8051 ,//作品不存在
    ROLE_WORK_MAX = 8052 ,//作品已经非常完美
    ROLE_CHANGE_NAME_LESS = 8053 ,//名字不能少于2个字符
    ROLE_NO_NICKNAME = 8054 ,//明星已经是这个名字
    ROLE_SKILL_MAX = 8055 ,//技能已经达到最高等级
    ROLE_SKILL_NONE = 8056 ,//升级技能不存在
    ROEL_LEVEL_NOT_ENOUGH = 8057 ,//员工等级不够
    ROLE_BADGE_MAX = 8058 ,//徽章已经达到最高等级
    ROLE_DEGREE_NOT_ENOUGH = 8059 ,//小伙伴的职位不够
    ROLE_BADGE_NONE = 8060 ,//还未拥有徽章
    ROLE_BADGE_ATTR_TOO_LONG = 8061 ,//升级徽章以解锁更多的属性
    ROLE_DEGREE_MAX = 8062 ,//小伙伴职位已经达到最高等级
    ROLE_MAIN = 8063 ,//主角不能作为消耗品
    ROLE_NOT_MAIN = 8064 ,//主角不能进行此操作
    ROLE_LEVEL_NOT_ENOUGH = 8065 ,//小伙伴的等级不满足
    ROLE_NUM_NOT_ENOUGH = 8066 ,//小伙伴的数量不足
    ROLE_IN_DEPLOY = 8067 ,//小伙伴在队伍中
    MAIN_ROLE_UP_CAN_UPMAX = 8068 ,//主角升级可提高等级上限
    ROLE_PASSIVESKILL_LOCK = 8069 ,//技能还未解锁
    NOT_ENERGY = 8070 ,//技能点不足
    UP_SMALLFRIEND_LEVEL_UP_LIMIT = 8071 ,//伙伴升级可提高技能等级上限
    ROLE_BUY_SKILL_POINT_NO_TIMES = 8072 ,//购买次数已经用完，可以通过提升VIP增加购买次数
    ROLE_STRONG_NEED_SELECT = 8073 ,//强化过的副卡，需要手动选择哦！
    
    //好友模块 9
    FRIEND_APPLY_AGAIN = 90001 ,//已经给对方发过好友申请了
    FRIEND_NOT_FOUND = 90002 ,//好友不存在
    FRIEND_ADD_SELF = 90003 ,//加自己有意思嘛
    FREIND_ADD_BLACKLIST = 90004 ,//你在对方黑名单中
    EXIST_IN_FRIENDGROUP = 90005 ,//双方已经是好友了
    FRIENDGROUP_GT_UPPER_LIMIT = 90006 ,//好友已满
    FRIEND_UPPER_LIMIT = 90007 ,//对方好友已满
    FRIEND_MESSAGE_EMPTY = 90008 ,//发送信息为空
    FRIEND_HAS_GIVE_POWER = 90009 ,//已经赠送过体力给此好友
    FRIEND_NO_POWER_GET = 90010 ,//没有可以领取的体力
    FRIEND_GET_MORE_TIME = 90011 ,//提升VIP等级可领取更多体力
    FRIEND_ONE_GIVE_NOT = 90012 ,//没有可以赠送的好友
    
    //公司模块 10
    SYN_YES = 10001 ,//可以
    SYN_NO = 10002 ,//不可以
    SYN_NO_EXIST = 10003 ,//公司不存在
    SYN_NAME_EXISTED = 10004 ,//这个名字已经被注册过了
    SYN_NOT_FREE_PLAYER = 10005 ,//玩家已经有公司了
    SYN_NO_JOB_POWER = 10006 ,//玩家的权限等级不够
    SYN_MEMBER_NO_EXIST = 10007 ,//找不到成员
    SYN_MANAGER_NUM_LIMIT = 10008 ,//职位已满
    SYN_APPOINT_JOB = 10009 ,//职位任命
    SYN_DISMISS_JOB = 10010 ,//解除职位
    SYN_NEW_MEMBER = 10011 ,//添加新成员
    SYN_KICKOUT_MEMBER = 10012 ,//开除成员
    SYN_QUIT_FACTION = 10013 ,//退出公司
    SYN_MASTER_TRANSFER = 10014 ,//会长转让
    SYN_MEMBER_ONLINE = 10015 ,//成员在线
    SYN_MEMBER_OFFLINE = 10016 ,//成员离线
    SYN_REQUEST_NOT_EXIST = 10017 ,//申请不存在
    SYN_FULL_MEMBER = 10018 ,//成员已满
    SYN_REQUEST_NUM_LIMIT = 10019 ,//已经在申请列表中
    SYN_CHEQUE_NOT_ENOUGH = 10020 ,//宗门粮饷不足
    SYN_UPDATE_MEMBER = 10021 ,//宗门成员信息更新
    SYN_DELETE_MEMBER = 10022 ,//删除宗门成员
    SYN_KICK_MAX = 10023 ,//今天已经不能再踢人了
    SYN_LEVEL_NOT_ENOUGH = 10024 ,//公司等级不够
    SYN_MASTER_NOT_OFFLINE_7DAY = 10025 ,//会长离线满7天才能被顶替
    SYN_TODAY_BUILD_MAX = 10026 ,//公司今天已经到达最大建设上限，请明天再来建设
    SYN_NONE = 10027 ,//还未加入粉丝会，不能进入
    
    SYNWAR_IS_IN_WAR = 10101 ,//已经发起了宗门战
    SYNWAR_WAR_NO_EXIST = 10102 ,//战争不存在
    SYNWAR_CHALLENGE_NOT_ENOUGH = 10103 ,//挑战次数不足
    SYNWAR_IS_IN_POSITION = 10104 ,//重复上阵
    
    //活动模块 11
    ACTIVITY_CONFIG_ERROR = 11000 ,//活动配置错误，请联系GM
    ACTIVITY_OVER = 11001 ,//活动已结束
    ACTIVITY_NO_TIMES = 11002 ,//活动领取次数不足
    ACTIVITY_CONDITION_NO_ENOUGH = 11003 ,//领取条件不足
    ACTIVITY_HAS_JOIN = 11004 ,//已参加过活动
    ACTIVITY_AWARD_FAIL = 11005 ,//活动奖励领取失败，请重新再试
    ACTIVITY_ROLE_DEPLOY = 11051 ,//明星还在阵中，无法兑换!
    ACTIVITY_TIMES_MAX = 11052 ,//参与活动次数已满
    ACTIVITY_TRAIN_NOT_PASS = 11053 ,//还未通过考核
    DAILYJOIN_AWARD_NOT_FOUND = 11101 ,//奖励不存在
    DAILYJOIN_JOIN_VALUE = 11102 ,//奖励所需参与度不足
    GIFTBAG_NO_FOUND = 11111 ,//邀请码不存在或已过期
    GIFTBAG_HAS_USE = 11112 ,//邀请码已使用
    GIFTBAG_PLATFORM_INVLID = 11113 ,//邀请码不适合您
    GIFTBAG_TYPE_FULL = 11114 ,//类似的邀请码你领取的过多了
    
    //幸运寻宝 1121
    TREASURE_CONFIG_ERROR = 11200 ,//幸运寻宝配置错误，请联系GM
    TREASURE_HUNT_ENGOUGH = 11201 ,//探宝次数不足
    
    //月卡相关
    NO_MONTHCARD = 11300 ,//没有购买月卡
    HAS_FOREVER_MONTHCARD = 11301 ,//已经拥有永久月卡
    HAS_GET_MONTHCARD_AWARD = 11302 ,//今日已经领取月卡奖励
    
    //28奖项争夺
    SUPERSPORT_TIMES_ZERO = 28101 ,//奖项挑战次数不足，请及时购买
    
    //冲塔模块 40
    RUSHTOWER_REFRESH = 40000 ,//副本已重置，重新进入后可刷新
    RUSHTOWER_NO_MONSTER = 40001 ,//怪物信息配置不正确
    RUSHTOWER_TIMES_ZERO = 40101 ,//没有冲塔次数
    RUSHTOWER_NO_OPEN = 40102 ,//活动还未开启
    RUSHTOWER_RUSH_CLOSE = 40103 ,//今天活动已经结束
    RUSHTOWER_SCORE_NO_ENOUGH = 40401 ,//分值不够
    RUSHTOWER_AWARD_NONE = 40402 ,//奖励为空
    
    //商城模块 49
    SHOP_GOODS_NOT_ENOUGH = 49001 ,//可购买的数量不足
    SHOP_INVALID_ID = 49002 ,//无效商品
    SHOP_SALE_CLOSE = 49003 ,//商品下架
    SHOP_LIMIT_TIMES = 49004 ,//购买次数不足
    SHOP_ROLE_RANDOM_FAILURE = 49005 ,//签约明星失败
    
    //充值模块 51
    PAY_ORDER_NOFOUND = 51201 ,//支付订单不存在
    PAY_WAITING = 51202 ,//正在支付，稍候再试
    PAY_HAS_PAID = 51200 ,//已经支付
    PAY_NO_GIFTBAG = 51301 ,//未消费不能获取礼包
    PAY_HAS_GIFTBAG = 51302 ,//首冲礼包已经领取
    PAY_INVALID_ID = 51300 ,//无效充值项
    
    //章节关卡模块57
    PLOTPOINT_STAR_NOT_ENOUGH = 57001 ,//星级不够，还无法扫荡
    
    //地图模块58
    RICHMAP_NO_EXIST = 58001 ,//地图不存在
    RICHMAP_CANNOT_ENTER = 58002 ,//无法进入的地图
    RICHMAP_ADD_BUFF = 58003 ,//加BUFF
    RICHMAP_DEL_BUFF = 58004 ,//删除BUFF
    RICHMAP_HAS_NO_ENTER = 58005 ,//还没进入任何区域
    RICHMAP_MAIN_ROLE_DIE = 58006 ,//主角阵亡，复活后才能继续
    RICHMAP_TARGETS_NOT_ALL = 58007 ,//还未完成所有目标，不能扫荡
    RICHMAP_HAS_ENTER_OTHER = 58008 ,//已经在旅行
    
    //竞技场模块60
    RANKTOPLIST_RANK_NO_MATCH = 60001 ,//对手排名发生变化，排名已更新
    RANKTOPLIST_NO_IN_REVENGE = 60002 ,//不在复仇列表
    RANKTOPLIST_CHALLENGE_NOT_ENOUGH = 60003 ,//挑战次数不足
    
    //竞猜模块61
    EVENTLOTTERIES_NO_EXIST = 61001 ,//竞猜不存在
    EVENTLOTTERIES_NOT_OPEN = 61002 ,//竞猜活动未开启
    EVENTLOTTERIES_NOT_INBET = 61003 ,//不在下注时间
    EVENTLOTTERIES_HASNOT_BET = 61004 ,//未下注
    EVENTLOTTERIES_BET_ALREADY = 61005 ,//已经下注过了
    
    //世界BOSS模块62
    WORLDBOSS_NOT_IN_TIME = 62001 ,//不在活动时间内
    WORLDBOSS_IS_DIE = 62002 ,//BOSS已被击杀
    
    //偶像系统模块63
    GARDEN_TODAY_QIDAO_MAX = 63001 ,//每天最多可以祈祷3轮，今日祈祷机会已用完
    GARDEN_QIDAO_MAX = 63002 ,//本轮祈祷次数已用完
    GARDEN_PLANT_CAN_NOT_STEAL = 63003 ,//植物还未成熟
    GARDEN_PLANT_CAN_NOT_WEATER = 63004 ,//植物已成熟，不需要再浇水
    GARDEN_WEATER_SECOND = 63005 ,//不能重复浇水
    GARDEN_STEAL_SECOND = 63006 ,//爷，您已经偷过我一次了，求您放过我吧！
    GARDEN_WEATER_MAX = 63007 ,//已经不需要再浇水了
    GARDEN_STEAL_MAX = 63008 ,//爷，我已经被偷掉一半了，您去偷别的花园吧!
    
    //通告系统模块90
    TARGETS_NOT_GET = 9001 ,//该工作已过期
    TARGETS_NOT_COMPLETE = 9002 ,//打工还未完成
    TARGETS_CAN_NOT_PULL_DOWN = 9003 ,//不能接受该打工
    TARGETS_HAS_IN = 9004 ,//打工已经在进行
    TARGETS_ROEL_HAS_IN = 9005 ,//有小伙伴已经在进行其它的工作
    TARGETS_CONDITION_NOT_FIT = 9006 ,//目前没有新的工作哦~
    TARGETS_ROLE_NOT_ENOUGH = 9007 ,//小伙伴数量不足
    TARGET_COMPLETE_WAYS_NOT = 9008 ,//打工不能完成
    TARGET_NOT_EXIT = 9009 ,//该打工不存在
    TARGET_IS_COMPLETE = 9010 ,//打工已经完成
    TARGETS_GOLD_NOT_FIT = 9011 ,//还未完成所有金币任务，不能领取
    TARGET_TRAIN_NOT_EXIST = 9012 ,//对应的训练不存在
    TARGET_TRAIN_NOT_OPEN = 9013 ,//训练还没开放
    TARGET_TRAIN_HAS_GET = 9014 ,//今天已经参加过训练了
    
    //天赋模块100
    TALENT_NUM_NOT_ENOUGH = 1000001 ,//天赋点不足
    TALENT_PRE_ID_NO_ENOUGH = 1000002 ,//前置天赋不满足
    TALENT_ID_NOT_IN_STAGE = 1000003 ,//没有此天赋
    TALENT_ACTIVE_NUM_NOT_ENOUGH = 1000004 ,//激活的天赋点数不足
    TALENT_NUM_MAX = 1000005 ,//当前天赋点已经达到最大值
    TALENT_HAS_NO_REST = 1000006 ,//没有需要重置的天赋点
    }
}