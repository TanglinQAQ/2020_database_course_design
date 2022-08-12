<template>
  <div id="home">
    <!--页头-->
    <el-header>发布项目</el-header>
    <el-main>
      <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="160px" class="demo-ruleForm">
      <el-form-item label="项目名称" prop="project_name">
          <el-input v-model="ruleForm.project_name"></el-input>
        </el-form-item>
        <el-form-item label="项目背景" prop="project_background">
          <el-input v-model="ruleForm.project_background"></el-input>
        </el-form-item>
        <el-form-item label="项目简介" prop="project_introduction">
          <el-input v-model="ruleForm.project_introduction"></el-input>
        </el-form-item>
        <el-form-item label="项目内容" prop="project_content">
          <el-input v-model="ruleForm.project_content"></el-input>
        </el-form-item>
        <el-form-item label="起止时间" prop="due">
          <el-date-picker
            v-model="ruleForm.due" 
            type="datetimerange"
            range-separator="至"
            start-placeholder="开始日期"
            end-placeholder="结束日期"
            style="float: left"
            format="yyyy-MM-dd HH:mm:ss"
            value-format="yyyy-MM-dd HH:mm:ss">
          </el-date-picker>
        </el-form-item>
        <el-form-item label="项目当前进度" prop="project_progress">
          <el-select v-model="ruleForm.project_progress" placeholder="请选择项目当前进度">
            <el-option label="准备阶段" value="1"></el-option>
            <el-option label="规划阶段" value="2"></el-option>
            <el-option label="起步阶段" value="3"></el-option>
            <el-option label="中期阶段" value="4"></el-option>
            <el-option label="收尾阶段" value="5"></el-option>
          </el-select>
        </el-form-item>
         <el-form-item label="是否有组队需求" prop="project_status">
          <el-select v-model="ruleForm.project_status" placeholder="请选择是否有组队需求">
            <el-option label="是" value="1"></el-option>
            <el-option label="否" value="2"></el-option>
          </el-select>
        </el-form-item>
        <div v-if="ruleForm.project_status === '1'">
        <el-form-item label="组队目的" prop="purpose">
          <el-input v-model="ruleForm.purpose"></el-input>
        </el-form-item>
        <el-form-item label="组队类型" prop="team_type">
          <el-select v-model="ruleForm.team_type" placeholder="请选择组队类型" @change="teamtypecheck">
            <el-option label="竞赛组队" value="竞赛"></el-option>
            <el-option label="课程项目组队" value="课程项目"></el-option>
          </el-select>
          <el-cascader :options="options" :props="props" :show-all-levels="false" clearable
            v-model="ruleForm.team_type_detail" v-show="detailshow" placeholder="请选择组队具体情况"></el-cascader>
        </el-form-item>
        <el-form-item label="组队人数" prop="team_limit">
          <el-select v-model="ruleForm.team_limit" placeholder="请选择组队人数">
            <el-option label="3" value="3"></el-option>
            <el-option label="4" value="4"></el-option>
            <el-option label="5" value="5"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="组队校区" prop="region">
          <el-checkbox-group v-model="ruleForm.region" id="checkbox">
            <el-checkbox label="四平" name="region"></el-checkbox>
            <el-checkbox label="嘉定" name="region"></el-checkbox>
            <el-checkbox label="沪西" name="region"></el-checkbox>
            <el-checkbox label="沪北" name="region"></el-checkbox>
          </el-checkbox-group>
        </el-form-item>
        <el-form-item label="需求细则" prop="details">
          <el-input type="textarea" v-model="ruleForm.details"></el-input>
        </el-form-item>
        </div>
        <el-form-item>
          <el-button type="primary" @click="submitForm('ruleForm')">立即创建</el-button>
          <el-button @click="resetForm('ruleForm')">重置</el-button>
        </el-form-item>
      </el-form>
    </el-main>
  </div>
</template>



<script>
import global_msg from '../utils/global.js'
import { createprojectlist } from '@/api/createprojectlist.js'
export default {
  name: 'CreatprojectList',
  data() {
    return {
      detailshow: false,
      props: { multiple: true },//级联选择器确定选项选不选择
      checkList: [],
      ruleForm: {
        project_id: '',
        project_name: '',
        project_background: '',
        project_introduction: '',
        project_content: '',
        due:'',
        project_progress: '',
      },
      rules: {
         project_name: [
          { required: true, message: '请输入项目名称', trigger: 'blur' },
          { min: 3, max: 80, message: '长度在 3-80 个字符以内', trigger: 'blur' }
        ],
        project_background: [
          { required: true, message: '请输入项目背景', trigger: 'blur' },
          { min: 3, max: 80, message: '长度在 3-80 个字符以内', trigger: 'blur' }
        ],
        project_introduction: [
          { required: true, message: '请输入项目简介', trigger: 'blur' },
          { min: 3, max: 80, message: '长度在 3-80 个字符以内', trigger: 'blur' }
        ],
        project_content: [
          { required: true, message: '请输入项目内容', trigger: 'blur' },
          { min: 3, max: 80, message: '长度在 3-80 个字符以内', trigger: 'blur' }
        ],
        due: [
          { required: true, message: '请选择时间', trigger: 'blur' },
        ],
        project_progress: [
          { required: true, message: '请选择项目当前进度', trigger: 'blur' },
        ],
        project_status: [
          { required: true, message: '请选择是否有组队需求', trigger: 'blur' },
        ]
      }
    };
  },
  methods: {
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          console.log('submit!');
        } else {
          console.log('error submit!!');
          return false;
        }
      });
      let vm = this;
      //请求地址,this和vm指的是全局
      let param = {
        project_id: this.ruleForm.project_id,
        project_name: this.ruleForm.project_name,
        project_background: this.ruleForm.project_background,
        project_introduction: this.ruleForm.project_introduction,
        project_content: this.ruleForm.project_content,
        project_progress: this.ruleForm.project_progress,
      }
      createprojectlist(param).then(function (res) {
        if (res.data === false) {
          vm.$message.error("提交失败");
          vm.resetForm(formName);
        } else {
          vm.$message.success("提交成功");
          vm.$router.push({ path: "/users/InforList" }); //接下来进入到哪个路由
        }
      })
    },
  }
}
</script>

<style scoped>
.el-header,
.el-footer {
  font-weight:900;
  font-size:24px;
  background-color: #B3C0D1;
  color: #333;
  text-align: center;
  line-height: 60px;
}
.el-main {
  background-color: #ecf0f5;
  color: #333;
  text-align: left;
  line-height: 220px;
  height: 100%;
}
#home {
  width: 100%;
  min-height: 100vh;
  background-color: #ecf0f5;
  background-size: 100% 100%;
}
.demo-ruleForm >>> .el-form-item__label /*标题的字体大小 */
{
  font-size: 18px;
}
#checkbox >>> .el-checkbox__label /*复选框的字体大小 */
{
  font-size: 18px;
}
</style>