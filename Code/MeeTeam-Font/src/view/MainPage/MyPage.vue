<template>
    <div id="user_page">
        <div id="nav">
            <img src="../../assets/logo.png" id="logo" height="40px" />
            <span id="title">|</span>
            <span id="title"> 个人信息            </span>
            <div id="user_id">
                <el-link type="info" @click="goto_userInfo()" style="color:white;font-size: 20px;">
                    <span v-text="user_id"></span>
                </el-link>
            </div>
        </div>
        <div id="body">
            <div id="side_menu">
                <el-row class="tac">
                    <el-col>
                        <el-menu default-active="2" class="el-menu-vertical-demo" background-color="#545c64"
                            text-color="#fff" active-text-color="#ffd04b" :router="true">
                            <el-menu-item index="/users/UserPage">
                                <i class="el-icon-s-home"></i>首页
                                </el-menu-item>
                            <el-menu-item index="/users/UserInformation">
                                <i class="el-icon-user"></i>个人信息
                            </el-menu-item>
                            <el-menu-item index="/users/UserInformation">     //还没写好
                                <i class="el-icon-star-off"></i>我的收藏
                            </el-menu-item>
                             <el-menu-item index="/users/UserInformation">       //还没写好
                                <i class="el-icon-time"></i>历史记录
                            </el-menu-item>
                            <el-menu-item index="/users/NoticeList">
                                <i class="el-icon-s-home"></i>平台通知
                            </el-menu-item>
                        </el-menu>
                    </el-col>
                </el-row>
            </div>
            <div id="main">
                <el-main>
                    <router-view></router-view>
                </el-main>
            </div>
        </div>
    </div>
</template>

<script>
import global_msg from '../../utils/global.js'
export default {
    data() {
        return {
            user_id: ''
        }
    },
    created() {
        this.get_user();
    },
    methods: {
        get_user() {
            this.user_id = global_msg.nowuserid;
        },
        goto_userInfo() {
            this.$router.push({ path: "/users/MyPage" });
        }
    }
}
</script>

<style>
#user_page {
    caret-color: transparent;
}


#nav {
    background-color: black;
    height: 60px;
    width: 100%;
    display: flex;
    padding-left: 0;
    align-items: center;
    color: white;
    font-size: 20px;

}

#user_id {
    margin-left: 65%;
}


.el-link {
    font-size: 20px;
}

#user_page {
    background-color: white;
    background-size: 100% 100%;
}

#logo {
    margin-left: 20px;
}

#title {
    margin-left: 20px;
}

#side_menu {
    position: absolute;
    width: 15%;
    margin-top: 0px;
    height: 100%;
    background-color: #545c64;
}
</style>

