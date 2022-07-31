<template>
 <div id="creatteam-container">
    <div style="text-align: center;height: 50px">
    </div>
    <el-form :model="ruleForm" status-icon :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
      <el-form-item>
        <el-button type="primary" @click="submitForm('ruleForm')">发布</el-button>
      </el-form-item>
    </el-form>
  </div>

</template>

<script>
export default {
name: 'InforList',
 methods:{
  submitForm(formName) {
     var vm = this;
     vm.$router.push({path: "/users/CreatList"}); //接下来进入到创建项目的页面
  }
 }
}
</script>

<style>

</style>