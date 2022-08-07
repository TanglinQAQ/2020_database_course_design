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
            <div id="app">
              <h2 v-text="title"></h2>
              <span v-text="content"></span>
            </div>
            <el-button type="text" @click="goto_create_notice()">编辑公告</el-button>
          </el-main>
        </el-container>
      </el-container>
    </div>
  </div>
</template>
 
<script>
/* global Vue */
import { get_notice } from '@/api/notice.js'
let not = {
  notice_title: '',
  notice_content: ''
};
export default {
  data() {
    console.log("运行");
    let para = {
      id: this.$route.query.n_id
    };
    get_notice(para).then(function (res) {
      not.notice_title = res.data.notice_title;
      not.notice_content = res.data.notice_content;
    })
    let res = {
      title: not.notice_title,
      content: not.notice_content
    };
    console.log(res);
    return res;
  },
  methods: {
    goto_NoticeList() {
      this.$router.push({ path: "/Admin/NoticeList" });
    },
    goto_create_notice() {
      var n_id = this.$route.query.n_id;
      this.$router.push({ path: "/Admin/CreateNotice", query: { n_id: n_id } });
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