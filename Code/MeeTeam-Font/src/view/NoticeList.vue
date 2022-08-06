<template>
  <div>
    <div id="header">
      <el-header>
        <el-page-header @back="goto_AdminSpace()" content="通知管理">
        </el-page-header>
      </el-header>
    </div>
    <div id="main_page">
      <el-container id="admin_page">
        <el-aside width="200px">
          <el-menu default-active="/Admin/NoticeList" router>
            <el-menu-item index="/Admin/NoticeList" >
              <i class="el-icon-s-order"></i>
              <span>通知总览</span>
            </el-menu-item>
            <!--此处为暂时的路径，等编辑页面做好时候再改-->
            <el-menu-item index="/Admin/AdminPage">
              <i class="el-icon-plus"></i>
              <span>新建通知</span>
            </el-menu-item>
          </el-menu>
        </el-aside>
        <el-container>
          <el-main>
            <el-table :data="tableData" border>
              <el-table-column prop="title" label="公告标题" align="left" style="margin: 50px;">
              </el-table-column>
              <el-table-column prop="admin_id" label="管理员" align="center">
              </el-table-column>
              <el-table-column prop="operate_time" label="上次修改时间" align="center">
              </el-table-column>
            </el-table>
          </el-main>
        </el-container>
      </el-container>
    </div>
  </div>
</template>
 
<script>
import { get_all } from '@/api/notice'
export default {
  data() {
    this.tableData = [];
    get_all().then(res => {
      Object.keys(res.data).forEach(v => {
        let o = {};
        o.title = res.data[v].notice_title;
        o.admin_id = res.data[v].admin_id;
        o.operate_time = res.data[v].operate_time;
        console.log(o);
        this.tableData.push(o);
      })
    })
    return {};
  },
  methods: {
    goto_AdminSpace() {
      this.$router.push({ path: "/Admin/AdminPage" });
    }
  }
}
</script>

<style>
#admin_page {
  position: absolute;
  top: 60px;
  left: 0%;
  right: 0%;
  bottom: 0%;
}

#header {
  height: 60px;
}

.el-page-header {
  text-align: center;
  padding-top: 20px;
}

.el-aside {
  background-color: #D3DCE6;
  color: #333;
  text-align: center;
}

.el-main {
  background-color: #E9EEF3;
  color: #333;
  text-align: center;
}
</style>