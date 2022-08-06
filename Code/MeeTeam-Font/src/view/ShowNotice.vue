<template>
  <div>
    <div id="header">
      <el-header>
        <el-page-header @back="goto_NoticeList()" content="公告详情">
        </el-page-header>
      </el-header>
    </div>
    <div id="main_page">
      <el-container id="admin_page">
        <el-container>
          <el-main>
              <el-button type="text" @click="goto_create_notice(notice_id)">编辑公告</el-button>
          </el-main>
        </el-container>
      </el-container>
    </div>
  </div>
</template>
 
<script>
import { get_all } from '@/api/notice.js'
export default {
  data() {
    this.tableData = [];
    get_all().then(res => {
      Object.keys(res.data).forEach(v => {
        let o = {};
        o.notice_id = res.data[v].notice_id;
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
    goto_NoticeList() {
      this.$router.push({ path: "/Admin/NoticeList" });
    },
    goto_create_notice(notice_id) {
        this.$router.push({path: "/Admin/create_notice", query: { n_id: notice_id } });
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