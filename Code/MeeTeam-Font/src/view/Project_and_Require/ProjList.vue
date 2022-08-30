<template>
<el-main>
        <div id="breadcrumb">
            <el-breadcrumb separator-class="el-icon-arrow-right">
                <el-breadcrumb-item :to="{ path: '/users/UserPage' }">首页</el-breadcrumb-item>
                <el-breadcrumb-item>项目管理</el-breadcrumb-item>
                <el-breadcrumb-item>平台项目列表</el-breadcrumb-item>
            </el-breadcrumb>
        </div>
        <div style="height: 50px;">
            <el-autocomplete class="inline-input" v-model="state1" :fetch-suggestions="querySearch" placeholder="项目名称"
                @select="handleSelect" style="float:left;margin-right:30px;width:150px;"></el-autocomplete>
            <el-autocomplete class="inline-input" v-model="state1" :fetch-suggestions="querySearch" placeholder="项目发布人"
                @select="handleSelect" style="float:left;margin-right:30px;width:150px;"></el-autocomplete>
            <el-select v-model="value2" multiple placeholder="项目当前进度" style="float:left;margin-right:30px;width:150px;">
                <el-option v-for="item in options3" :key="item.value" :label="item.label" :value="item.value">
                </el-option>
            </el-select>
            <el-select v-model="value2" multiple placeholder="是否有组队需求"
                style="float:left;margin-right:30px;width:150px;">
                <el-option v-for="item in options3" :key="item.value" :label="item.label" :value="item.value">
                </el-option>
            </el-select>
            <el-button class="filter-item" type="primary" icon="el-icon-search" @click="searchContList"
                style="float:left">
                搜索
            </el-button>
        </div>
        <br>
        <template>
            <el-row>
                <el-col v-for="(o, index) in 2" :key="o" :span="8" :offset="index > 0 ? 2 : 0">
                    <el-card :body-style="{ padding: '0px' }">
                        <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
                            class="image" />
                        <div style="padding: 14px">
                            <span>Yummy hamburger</span>
                            <div class="bottom">
                                <time class="time">{{  currentDate  }}</time>
                                <el-button text class="button">Operating</el-button>
                            </div>
                        </div>
                    </el-card>
                </el-col>
            </el-row>
        </template>
    </el-main>
</template>

<script lang="ts" setup>
import { ref } from 'vue'

const currentDate = ref(new Date())
</script>
    
<style>
.time {
    font-size: 12px;
    color: #999;
}

.bottom {
    margin-top: 13px;
    line-height: 12px;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.button {
    padding: 0;
    min-height: auto;
}

.image {
    width: 100%;
    display: block;
}
</style>

