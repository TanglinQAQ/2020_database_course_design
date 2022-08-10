<template>
    <div id="admin_page">
        <div id="nav">
            <img src="../assets/logo.png" id="logo" height="40px" />
            <span id="title">|</span>
            <span id="title">平台管理</span>
        </div>
        <div id="body">
            <div id="side_menu">
                <el-row class="tac">
                    <el-col>
                        <el-menu default-active="2" class="el-menu-vertical-demo" background-color="#545c64"
                            text-color="#fff" active-text-color="#ffd04b" :router="true">
                            <el-menu-item index="/Admin/AdminPage">主页</el-menu-item>
                            <el-submenu index="1">
                                <template slot="title">
                                    <i class="el-icon-s-custom"></i>
                                    <span>审核管理</span>
                                </template>
                                <el-menu-item-group>
                                    <el-menu-item index="1-1">审核项目</el-menu-item>
                                    <el-menu-item index="1-2">审核需求</el-menu-item>
                                </el-menu-item-group>
                            </el-submenu>
                            <el-submenu index="2">
                                <template slot="title">
                                    <i class="el-icon-notebook-2"></i>
                                    <span>通知管理</span>
                                </template>
                                <el-menu-item-group>
                                    <el-menu-item index="/Admin/NoticeList">通知总览</el-menu-item>
                                    <el-menu-item index="/Admin/CreateNotice">新建通知</el-menu-item>
                                </el-menu-item-group>
                            </el-submenu>
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
import AdminPage from './AdminPage.vue'
import NoticeList from './NoticeList.vue'
export default {
    routes: [{
        path: './AdminPage',
        component: AdminPage,
        children: [
            { path: './NoticeList', component: NoticeList }
        ]
    }]
}
</script>

<style>
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

#admin_page {
    background-color: #ecf0f5;
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