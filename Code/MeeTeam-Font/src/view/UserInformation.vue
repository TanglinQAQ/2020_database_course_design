<template>
  <div id="creatteam-container">
    <el-container style="height: 100%; border: 1px solid #eee">
      <el-aside width="200px" style="background-color: rgb(238, 241, 246)">
        <el-menu :default-openeds="['1', '3']">
          <el-submenu index="1">
            <template slot="title"><i class="el-icon-user"></i>个人信息</template>
          </el-submenu>
          <el-submenu index="2">
            <template slot="title"><i class="el-icon-star-off"></i>我的收藏</template>
          </el-submenu>
          <el-submenu index="3">
            <template slot="title"><i class="el-icon-time"></i>历史记录</template>
          </el-submenu>
          <el-submenu index="4">
            <template slot="title"><i class="el-icon-bell"></i>消息通知</template>
          </el-submenu>
        </el-menu>
      </el-aside>
      <el-container>
       
       
      </el-container>
    </el-container>
  </div>
</template>

<script>
import global_msg from '../utils/global.js'
export default {
  name: 'UserInformation',
  data() {
    return {
      username: global_msg.nowuserid,
      tableData: [],
    };
  },
  mounted() {
    this.getlist() //页面一进入就加载表格
  },
  methods: {
    getlist() {
      var vm = this;//全局变量
     
    }
  }
}
</script>

<style>
#creatteam-container {
  position: relative;
  margin: 10px 0;
  margin-left: 0px;
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