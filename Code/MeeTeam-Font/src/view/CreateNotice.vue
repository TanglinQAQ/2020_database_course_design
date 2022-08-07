<template>
  <div>
    <div id="header">
      <el-header>
        <el-page-header @back="goto_NoticeList()" content="编辑公告">
        </el-page-header>
      </el-header>
    </div>
    <div id="main_page">
      <el-container id="edit_page">
        <el-main>
          <el-form ref="form">
            <el-form-item prop="notice_title">
              <el-input type="text" v-model="notice_title" placeholder="请输入公告标题"></el-input>
            </el-form-item>
            <el-form-item prop="notice_content">
              <el-input type="text" v-model="notice_content" placeholder="请输入公告内容"></el-input>
            </el-form-item>
            <el-form-item>
              <el-button type="info" @click="onSubmit(0)">暂存公告</el-button>
              <el-button type="primary" @click="onSubmit(1)">发布公告</el-button>
            </el-form-item>
          </el-form>
        </el-main>
      </el-container>
    </div>
  </div>
</template>

<script>
import {get_notice} from '@/api/notice.js'
import { create_notice } from '@/api/notice.js'
import global_msg from '../utils/global.js'
let form = {
  notice_title: '',
  notice_content: '',
};
export default {
  data() {
    if (this.$route.query.n_id) {
      let para = {
        id: this.$route.query.n_id
      };
      get_notice(para).then(function (res) {
        console.log(res.data);
        form.notice_title = res.data.notice_title;
        form.notice_content = res.data.notice_content;
      })
    }
    return form;
  },
  methods: {
    goto_NoticeList() {
      this.$router.push({ path: "/Admin/NoticeList" });
    },
    onSubmit(para) {
      form.admin_id = global_msg.nowadminid;
      let o = {
        notice_id: '',
        notice_title: form.notice_title,
        notice_content: form.notice_content,
        admin_id: global_msg.nowadminid,
        operate_type: para,
        operate_time: ''
      }
      var not = JSON.stringify(o);
      //console.log(res);
      create_notice(not).then(function (res) {
        if (!res) {
          alert("公告修改失败！");
        }
        else {
          if (para == 0) {
            alert("公告暂存成功！");
          }
          else {
            alert("公告发布成功！");
          }

        }
      })
    }
  }
}
</script>

<style>
#edit_page {
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

.el-main {
  background-color: #E9EEF3;
  color: #333;
  text-align: center;
}
</style>