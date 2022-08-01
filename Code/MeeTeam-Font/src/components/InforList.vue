<template>
 <div id="creatteam-container">
  <el-container style="height: 100%; border: 1px solid #eee">
   <el-aside width="200px" style="background-color: rgb(238, 241, 246)">
    <el-menu :default-openeds="['1', '3']">
      <el-submenu index="1">
        <template slot="title"><i class="el-icon-message"></i>组队类型</template>
        <el-submenu index="1-1">
          <template slot="title">竞赛组队</template>
          <el-menu-item index="1-1-1">创新创业</el-menu-item>
          <el-menu-item index="1-1-2">数学建模</el-menu-item>
          <el-menu-item index="1-1-3">学科竞赛</el-menu-item>
        </el-submenu>
        <el-submenu index="1-2">
          <template slot="title">项目课程组队</template>
          <el-menu-item index="2-1-1">人文学院</el-menu-item>
          <el-menu-item index="1-1-2">医学院</el-menu-item>
          <el-menu-item index="1-1-3">生命科学与技术学院</el-menu-item>
          <el-menu-item index="1-1-4">软件学院</el-menu-item>
        </el-submenu>
      </el-submenu>
      <el-submenu index="2">
        <template slot="title"><i class="el-icon-menu"></i>所在校区</template>
        <el-menu-item index="2-1">四平路校区</el-menu-item>
        <el-menu-item index="2-2">嘉定校区</el-menu-item>
        <el-menu-item index="2-3">沪西校区</el-menu-item>
        <el-menu-item index="2-4">沪北校区</el-menu-item>
      </el-submenu>
      <el-submenu index="3">
        <template slot="title"><i class="el-icon-setting"></i>导航三</template>
        <el-menu-item-group>
          <template slot="title">分组一</template>
          <el-menu-item index="3-1">选项1</el-menu-item>
          <el-menu-item index="3-2">选项2</el-menu-item>
        </el-menu-item-group>
        <el-menu-item-group title="分组2">
          <el-menu-item index="3-3">选项3</el-menu-item>
        </el-menu-item-group>
        <el-submenu index="3-4">
          <template slot="title">选项4</template>
          <el-menu-item index="3-4-1">选项4-1</el-menu-item>
        </el-submenu>
      </el-submenu>
    </el-menu>
  </el-aside>
  <el-container>
    <el-header style="text-align: right; font-size: 15px; top:50%;">
      <el-button type="primary" plain @click="additem">添加项目</el-button>
      <el-button type="warning" plain @click="deleteitem">我的项目</el-button>
      <el-dropdown>
        <i class="el-icon-setting" style="margin: 30px"></i>
        <el-dropdown-menu slot="dropdown">
          <el-dropdown-item>用户信息</el-dropdown-item>
          <el-dropdown-item>系统设置</el-dropdown-item>
        </el-dropdown-menu>
      </el-dropdown>
      <span>{{username}}</span>
    </el-header>
    <el-main>
      <el-table :data="tableData">
        <el-table-column prop="date" label="项目名称" width="140">
        </el-table-column>
        <el-table-column prop="name" label="组队发起人" width="140">
        </el-table-column>
        <el-table-column prop="address" label="项目类型" width="140">
        </el-table-column>
        <el-table-column prop="address" label="所在校区" width="140">
        </el-table-column>
        <el-table-column prop="address" label="项目简介" width="400">
        </el-table-column>
        <el-table-column prop="address" label="发布时间">
        </el-table-column>
      </el-table>
    </el-main>
  </el-container>
</el-container>
 </div>
</template>

<script>
import global_msg from '../utils/global.js'
export default {
name: 'InforList',
data(){
  return {
    username: global_msg.nowuserid,
  };
},
 methods:{
  additem:function() {
    this.$router.push({path: "/users/CreatList"}); //接下来进入到哪个路由
  }
 }
}
</script>

<style>
#creatteam-container{
  position: relative;
  margin: 10px 0; margin-left: 0px;
  height: 100%;
}
.el-header {
    background-color: #B3C0D1;
    color: #333;
    line-height: 60px;
  }
.el-aside {
    color: #333;
  }
</style>